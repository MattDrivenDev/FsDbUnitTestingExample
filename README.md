# Simple Stored Procedure Unit Testing

Using:

* F#
* SQL Type Provider

This is just a very small demo of how you can very simply use the F# SQL Type Provider to assert correct SQL Stored Procedure behaviour.

Obviously with a little refactoring, put into a different project type with a unit testing framework you could do a whole bunch of these quickly.

Why do this in F# instead of using a proper SQL Unit Testing solution? I'm just more comfortable in F# and comform leads to productivity.

## Usecase

You're deving a new stored procedure that performs some kind of operation and we want to assert that it does it correctly.

In this instance the stored procedure `up_MigrateData_TableA_To_TableB` will be populate `TableB` from a result set taken from `TableA`, where the `Name1` and `Name2` fields are merged.

Very simple, and very naive - but hopefully gets the point accross.

## Assumptions

The test script is expecting a database named `fsdbunit` to exist on a SQL Server/Instance `localhost`, which can be accessed with dbo permissions using Integrated Security.