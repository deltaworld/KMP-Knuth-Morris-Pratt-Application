Knuth-Morris-Pratt Prefix Table Render Application
==================================================

Implementation of the text/string searching and matching algorithm KMP Knuth-Morris-Pratt in visual C#.

This program renders the prefix function in a table fashion showing the index, string and the prefix value for each character
This will use the Knuth-Morris-Pratt to produce a prefix table for matching it with the pattern.

A sample run of the program on the pattern “ABXYABXZ” produces the following output:

i     si          pi  
1     A           0  
2     AB          0  
3     ABX         0  
4     ABXY        0  
5     ABXYA       1  
6     ABXYAB      2  
7     ABXYABX     3  
8     ABXYABXZ    0  

