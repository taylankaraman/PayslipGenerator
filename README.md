# Payslip Generator #

 - .net core 3.1 console application. Didn't want to use .net 5.0 since .net 3.1 is more stable and has until 2023 to upgrade to, by that time .net 6.0 which would be more stable.

- To run, build and use the executable with parameters.
- If you debug, the parameters are already defined in the application project properties as "Mary Song" 60000.
- Uses EF Core InMemoryDatabase. Tax table related data is populated at persistence project. Generate payslip uses DI to access repository. I used repository pattern to achieve this. 
- Created a separate service for each functionality so I can test them separately if I need to.
- Displaying the payslip is a separate service since rather than displaying the payslip to the console, some other method might be used in the future. Or an extra display method might be added alongside console. It would be easy to add that along with the test.