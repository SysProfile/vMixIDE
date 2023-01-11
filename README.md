# vMixIDE

Two important things that I want to clarify.

1. My native language is Spanish, although I can answer in English, some sentences may have grammar errors.
2. The application is not finished, it requires time and help from those who want to collaborate.

This app is powered by these two great GitHub projects.

* vmix-function-list [https://github.com/jensstigaard/vmix-function-list]
* FastColoredTextBox [https://github.com/PavelTorgashov/FastColoredTextBox]

**Undoubtedly**, one of the things that vMix should improve is code editing for development. Currently, it is a notepad that when saving changes does a syntax check.

I'm a .NET application developer and I've been doing it in Visual Basic for many years. To try to find a better way to develop, I'm making an external application that allows visualization using colors for syntax highlighting and most importantly, appending vMix's own functions using API.Function.

Below, you can see...

1. A variable is created
2. A value is assigned
3. Type "vmix."

This action brings all the vMix functions listed on the following github site [url]https://github.com/jensstigaard/vmix-function-list[/url]
![Autocomplete](https://user-images.githubusercontent.com/897014/211828175-d6629bf6-12a0-445d-80ed-e30a282fd4d4.png)

When selecting a function, SetText for this example, the system converts the line with the expression that vMix needs to work as seen in the following image.
![Autocompleted](https://user-images.githubusercontent.com/897014/211828415-add6250a-d2ce-4247-9466-e4e915a6e959.png)

If vMix is running, you can connect to it and load all the input's from your project. If they are of type GT, all the Text objects of that Input are loaded in the "Text fields" combo. If this action is prior to inserting the autocomplete "vmix.", it replaces the names with the ones selected in the combos.

Finally, in this example, you should just change the value to the variable as shown below
![Autocompleted variable](https://user-images.githubusercontent.com/897014/211828732-33acb6fd-4423-4adf-a5e4-d0e818459d85.png)

I have spent some time on other new features, this feature is under development

Typing "vb." displays some functions of the vMix "Visual Basic" language
![Input Find](https://user-images.githubusercontent.com/897014/211827937-7bf3859b-4e23-4d21-950a-6d5a7e7cf020.png)

Pressing Enter, this is the result
![Input Find example](https://user-images.githubusercontent.com/897014/211829201-344e3b42-969c-4bb0-ad4a-f028b09ee5a1.png)

