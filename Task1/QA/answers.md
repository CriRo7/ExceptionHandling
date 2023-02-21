1. What is the purpose of Exception Handling in C#? 
Exception Handling allows not only prevent application from crashes
but also helps to manage application flow. 
In Catch block we can decide continue, break or rethrow current execution flow 
if some exception was thrown

2. Can a try block have multiple catch blocks?
yes, from less general to base Exception block

3. Describe a flow how exceptions are handled? 
3.1. Exception thrown without try-catch block -> Application shouting down.
3.2. Exception thrown in try-catch block -> From place where exception was throw it bubbles up and tries to find first appropriate catch block.
3.3. Exception does not find appropriate catch block -> Application shutting down.
3.4. Exception does find appropriate catch block -> Log error, and decide what do with it.
3.5.1. Throw; -> throws exception bubble up.
3.5.2. Log -> exceptions logs and execution flow continues after catch block is executed

4. What is the base class from which all exceptions are derived? 
Exception 

5. What is the difference between Exception and Inner Exception?
Inner Exception can be created with Exception constructor parameter. Provides additional information where exception was thrown

6. What is the difference between throw ex; and throw; statements? 
throw ex; - loses call stack where exception was really thrown.
Should use throw; or throw new Exception('message', ex) // pass 'ex' to not lose stack trace

7. What is the purpose of finally statement? 
This statement executes whenever code throws or not the exception

8. What predefined .NET Exceptions do you know?
ArgumentException, ArgumentNullException, NullPointerException,
FileNotFoundException, FormatException, Exception

9. Is there a way to create a custom exception?
Yes - inherit from Exception class