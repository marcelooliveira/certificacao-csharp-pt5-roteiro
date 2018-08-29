Which two interfaces should you implement?
==========================================

[seenagape](https://www.briefmenow.org/microsoft/author/seenagape/ "View all posts by seenagape")[December 9, 2014](https://www.briefmenow.org/microsoft/which-two-interfaces-should-you-implement/ "Permalink to Which two interfaces should you implement?")

You are modifying an existing application that manages employee payroll. The application\
includes a class named PayrollProcessor. The PayrollProcessor class connects to a payroll\
database and processes batches of paychecks once a week.\
You need to ensure that the PayrollProcessor class supports iteration and releases\
database connections after the batch processing completes.\
Which two interfaces should you implement? (Each correct answer presents part of the\
complete solution. Choose two.)

A.\
IEquatable

B.\
IEnumerable

C.\
IDisposable

D.\
IComparable

> Explanation:\
> B: IEnumerable\
> C: IDisposable Interface\
> Exposes an enumerator, which supports a simple iteration over a non-generic collection.\
> Defines a method to release allocated resources.\
> The primary use of this interface is to release unmanaged resources.