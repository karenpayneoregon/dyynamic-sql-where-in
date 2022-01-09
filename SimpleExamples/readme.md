# About

Example using a CheckedListBox populated from SQL-Server with all company names used to take checked companies, create a WHERE IN on CompanyName and returned selections from the database.

Each company identifier has a proper parameter created rather than passing exposed strings.

For the screenshot below these are the parameter names.

```
@CompId0
@CompId1
@CompId2
@CompId3
@CompId4
```

The actual SQL via the parameters shown above. Command parameters are exposed using [ActualCommandText](https://github.com/karenpayneoregon/dyynamic-sql-where-in/blob/master/DbLibrary/LanguageExtensions/IDbExtensions.cs#L30:L88).

```sql
SELECT CompanyName FROM dbo.Company WHERE id IN (4,3,7,5,8)
```

![img](assets/whereInForm1.png)