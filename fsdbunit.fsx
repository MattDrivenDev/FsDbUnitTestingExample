#r "System.Data"
#r "System.Data.Linq"
#r "FSharp.Data.TypeProviders"

open System
open System.Data
open System.Data.Linq
open Microsoft.FSharp.Linq
open Microsoft.FSharp.Data.TypeProviders

[<Literal>]
let connectionString = "App=fsdbunit.fsx;Data Source=localhost;Initial Catalog=fsdbunit;Integrated Security=True;"

type FsDbUnit = SqlDataConnection<connectionString>

let db = FsDbUnit.GetDataContext(connectionString)


// ----------------------------------
// 1. ARRANGE
// ----------------------------------

// Insert us some test data into A
for i in [1..10] do
    let record = new FsDbUnit.ServiceTypes.TableA()
    record.TableA_Code <- sprintf "RECORD-%i" i
    record.TableA_Name1 <- sprintf "R-%i;" i
    record.TableA_Name2 <- sprintf "D-%i;" i
    db.TableA.InsertOnSubmit(record);

// Submit the changes made to A
do db.DataContext.SubmitChanges()


// ----------------------------------
// 2. ACT
// ----------------------------------

do db.Up_MigrateData_TableA_To_TableB() |> ignore


// ----------------------------------
// 3. ASSERT
// ----------------------------------
// We just care that the names are correctly merged...

// Generate the expected results
let expectedResults = query { 
    for row in db.TableA do  
    sortBy row.TableA_Code  
    select (sprintf "%s%s" row.TableA_Name1 row.TableA_Name2) }

// Read the actual results
let actualResults = query {
    for row in db.TableB do
    sortBy row.TableB_Code  
    select row.TableB_Name }

// Helper function
let namesAreEqual (expected:string) (actual:string) = expected = actual

// Check the Expected against Actual and print results.
Seq.map2 namesAreEqual expectedResults actualResults
|> Seq.iteri (printfn "Record %i: %b")


// ----------------------------------
// 4. CLEAN UP
// ----------------------------------

db.DataContext.ExecuteCommand("TRUNCATE TABLE [dbo].[TableA]")
db.DataContext.ExecuteCommand("DBCC CHECKIDENT('TableA', RESEED, 1);")

db.DataContext.ExecuteCommand("TRUNCATE TABLE [dbo].[TableB]")
db.DataContext.ExecuteCommand("DBCC CHECKIDENT('TableB', RESEED, 1);")