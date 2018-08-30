Which code segment should you insert at line 03?
================================================

You are developing a game that allows players to collect from 0 through 1000 coins. You are\
creating a method that will be used in the game. The method includes the following code.\
(Line numbers are included for reference only.)\
`\
01 public string FormatCoins(string name, int coins)\
02 {\
03\
04 }\
`\
The method must meet the following requirements:\
Return a string that includes the player name and the number of coins.\
Display the number of coins without leading zeros if the number is 1 or greater.\
Display the number of coins as a single 0 if the number is 0.\
You need to ensure that the method meets the requirements.\
Which code segment should you insert at line 03?\

```
A return String.Format("Player {0}, collected {1} coins", name, coins.ToString("###0"));
B. return String.Format("Player {0} collected {1:000#} coins.", name, coins);
C. return String.Format("Player {name} collected {coins.ToString('000')} coins");
D. return String.Format("Player {1} collected {2:D3} coins.", name, coins);
5. 
```

A.\
Option A

B.\
Option B

C.\
Option C

D.\
Option D