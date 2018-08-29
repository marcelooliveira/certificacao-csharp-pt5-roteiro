Which garbage collector method should you use?
==============================================

[seenagape](https://www.briefmenow.org/microsoft/author/seenagape/ "View all posts by seenagape")[December 9, 2014](https://www.briefmenow.org/microsoft/which-garbage-collector-method-should-you-use-4/ "Permalink to Which garbage collector method should you use?")

You are developing an application by using C#.\
The application includes an object that performs a long running process.\
You need to ensure that the garbage collector does not release the object's resources until\
the process completes.

Which garbage collector method should you use?

A.\
RemoveMemoryPressure()

B.\
ReRegisterForFinalize()

C.\
WaitForFullGCComplete()

D.\ ****** CORRETA
KeepAlive()