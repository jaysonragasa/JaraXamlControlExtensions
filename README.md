# JaraXamlControlExtensions
An extension libraries for XAML controls using attached attributes.  
https://github.com/jaysonragasa/JaraXamlControlExtensions  
  
# FORKED
forked from my old GitHub repo JaraIOGridControlAbstractions. I'm just moving stuff.

# Libraries
![](https://raw.githubusercontent.com/jaysonragasa/jaraimages/master/JaraXamlControlExtensions/2020-04-16_1543.png)  
![](https://raw.githubusercontent.com/jaysonragasa/jaraimages/master/JaraXamlControlExtensions/2020-04-16_1636.png)  

**GridEx**  
* There are 4 attached attributes where you can use for Grid and other elements. 3 of these primarily used for Grid and the other 1 is for whatever element you want to use it with.  
* Check the screenshot above to compare both XAML which has the same output when ran.

**GridEx Attached Attributes**  
* RowDefinitions, ColumnDefinitions, and GridDefinitions - You can use these attributes to create rows and columns inline!
* RowColumn - Use this attribute to position or span across your element in a grid.  

# Special characters  
In part of making it even more easier to create Rows and Columns. There are new special characters as an alternative to the following. But that does not mean you cannot use the old values.
* Tilde (~) is an alternative for Auto
* Space as an alternative for comma 
  
# Usage
**Add new namespace in your xaml**  
* UWP
  * `xmlns:jio="using:Jara.Xaml.Control.Extension"`
* WPF
  * `xmlns:jio="clr-namespace:Jara.Xaml.Control.Extension;assembly=Jara.Xaml.ControlExtensions.NetStandard"`
* WPF Core
  * `xmlns:jio="clr-namespace:Jara.Xaml.Control.Extension;assembly=Jara.Xaml.ControlExtensions.NetCore"`
* Xamarin
  * `xmlns:jio="clr-namespace:Jara.Xaml.Control.Extension;assembly=Jara.Xaml.ControlExtensions.Xamarin"`
  
**Creating rows or columns**  
```xaml <Grid jio:GridEx.RowDefinitions="Auto,*,2*,50,Auto">`  
or  
`<Grid jio:GridEx.RowDefinitions="Auto * 2* 50 auto">`  
or  
`<Grid jio:GridEx.RowDefinitions="~ * 2* 50 ~">`  
And these values can be used in `ColumnDefinitions` or `GridDefinitions`
  
**Creating rows AND columns**  
You can use `GridDefinition` if you're planning to add rows AND columns.  
Create 2 rows and 2 columns.  
`<Grid jio:GridEx.GridDefinitions="~ */~ *">`  
Notice the slash (/) which only separates the values for the Rows and Columns.  
  
**Placing your element to a specific row and column or span your element**  
use `RowColumn` to place an element in a specific row and column.  
* `<ListView jio:GridEx.RowColumn="1/0">` place the ListView  in the 2nd row and first column.  
* `<ListView jio:GridEx.RowColumn="1/0 2">` place the ListView in the 2nd row and first column and span upto the 2nd column.  
* `<ListView jio:GridEx.RowColumn="1 3/0">` place the ListView in the 2nd row and first column and span it upto the 3rd row.   

# History
## 1.3
* Added support for WPF, WPF Core, and UWP
* Added support ~ and (space) for RowDefinitions and ColumnDefinitions
  
## 1.2
* Added two new attached attributes called GridDefinitions and RowColumns
* You can use tilde (~) as an alternative to Auto
* Space as an alternative to comma (,)
* Slash (/) to separate Rows and Columns

i.e  
**GridDefinitions="~ \* / \* \*"**  
-- This will create 2 rows and 2 columns. The height of the first Row is set to Auto and the second is set to Star. Two new columns are set to Star. Note: Doesn't matter if you added spaces before and after the Slash. So it can be ="~ \*/\* \*"  
**GridDefinitions="~ ~/\*2 \*"**  
-- This is another example  
**GridDefinitions="/\*2 \*"**  
-- Notice the slash as the first chracter. This will create a column instead of a row.  
**GridDefinitions="\*2 \*/"**  or **GridDefinitions="\*2 \*"**  
-- Notice the slash at the end or the other doesn't have it? This will create rows only!  
**GridDefinitions="Auto ~ \*,\*"**  
-- This will create four rows. First and second row is set to Auto. Third and Forth are set to Star  
**RowColumn="0/1"**  
-- Will set the current element in the first row of the grid and in second column of the grid.  
**RowColumn="0 2/1"**  
-- Will set the current element in the first row of the grid spanning upto the second and then it will place the element in the second column.

## 1.1
* Added support for Absolute values. Originally accepting Auto * and n# only. So you can use Auto * n* and n now.  
i.e RowDefinitions="Auto,\*,3*,50"

## 1.0
* Implementation of RowDefinitions and ColumnDefinitions attached attributes
