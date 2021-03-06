# Backend Code Challenge

This repository contains a simple Remittance API written in C# for Majority.

## Running the application

To run this application, you will need to install Microsoft .NET 3.1 .
Use the User API inorder to generate the token to be used before calling the API.Currently user is fetched from config to avoid a registration api and keep the soln simple.

## Seeding the database

To initialize the database, set the environment variable `DBInit` to `True` in launchSettings.json. Once the database is seeded, don't forget to set it back to `False`.
MS SQL is used as the database and EntityFrameworkCore has been used to interact with the DB. Currently `DBInit` is placed in the IIS section of launch settings but please add it to WebAPI section in case you plan to run it via cmd prompt.

## API Details 
User API returns the token which would be required for calling all the below API's
1) get-bank-list returns the list of banks for the provided country
2) get-beneficiary-name returns the name of the beneficiary for the provided bank code and accountNumber 
3) get-country-list returns the list all the countries
4) get-exchange-rate returns the exchange rate for the provided countries
5) get-fees-list returns list of fees for a set of amounts based on the base rate
6) get-state-list returns list of all the states in the US
7) submit-transaction is used to submit a transaction and get-transaction-status fetches the transaction
