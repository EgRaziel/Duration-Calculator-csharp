# CSharp Duration Calculator
**Simple Duration Calculator (Sum and Subtract), made in C#**

## How To Use:

### When opening, select one of the options by typing the values, then press **Enter** to confirm:
- (**1** for **Sum**, **2** for **Subtract** and **0** to **Exit** the application);
- If you type a _different number_, the menu will repeat until you type a **valid** answer.

### Enter the initial duration in the format **_hh:mm:ss_** (Hours, Minutes and Seconds):
- For one digit values, you can type only one digit (without having to put a zero on the start. e.g., **6:30:0** is the same as **06:30:00**). You can chose what's better for you;
- If you have a value tha doesn't contemplate hours or minutes, you can use only the _minutes_ or _seconds_ when typing. (e.g., **30:0** will be converted into **00:30:00**, and **30** will be **00:00:30**);
- If you type an incorrect value (e.g., **00:aa:00**), the program will take the default value of **_00:00:00_**.

### Enter the final duration. The same _rules_ of `Initial Duration` are applied to it:
- Feel free to insert a _higher duration_ for the final duration when _subtracting_. The program will automatically identify the shorter value and place it as the _subtrahend_. (e.g., **1:30:0** - **2:0:0** will be treated as **2:0:0** - **1:30:0**).

### The `Result Duration` will be shown and the program will ask if you want to perform a new calc (_y_ for Yes and _n_ for No). Then press enter to confirm:
- Fell free to use _uppercase_ or _lowercase_. The program will automatically change it to _lowercase_;
- If you type something different of _y_ or _n_, the question will repeat, until you type a correct value.

### It will also ask the type of the calculation. If you want to perform a new _Sum_, or a new _Subtract_.
### When asked if you want to **perform a new calc**, if the answer is _n_ (No), the program will finish with a thanks message.