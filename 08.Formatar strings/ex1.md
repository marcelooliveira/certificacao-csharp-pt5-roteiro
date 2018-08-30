Which code should you insert at line 04?
========================================

HOTSPOT\
You are developing an application in C#.\
The application will display the temperature and the time at which the temperature was\
recorded. You have the following method (line numbers are included for reference only):\

```
01 public void DisplayTemperature(DataTime date, double temp)
02 {
03 	string output;
04 
05 	string lblMessage = output;
06 }

```

You need to ensure that the message displayed in the lblMessage object shows the time\
formatted according to the following requirements:\
The time must be formatted as hour:minute AM/PM, for example 2:00 PM.\
The date must be formatted as month/day/year, for example 04/21/2013.\
The temperature must be formatted to have two decimal places, for example 23-45.\
Which code should you insert at line 04? (To answer, select the appropriate options in the answer area.)\

```
output = string.Format(
"Temperature at [{0:t}|{1:t}|{0:hh:mm}|{1:hh:mm}]
 on 
[{0:d}|{1:d}|{0:dd/mm/yy}|{1:mm/dd/yy}]" 
[{0}|{1}|{0:N2}|{1:N2}]", date, temp)
```

Answer: 

```
output = string.Format(
"Temperature at [{0:t}] on {0:dd/mm/yy}" 
{1:N2}", date, temp)
```

