PersianCulture
==============

##<a id="samples">Samples</a>

####<a id="date-time-extensions">DateTime Extensions</a>
```C#
new DateTime(2014, 4, 19).ToLocalizedShortDateString() => "1393/01/30"
new DateTime(2014, 4, 19).ToLocalizedLongDateString()  => "30 (شنبه) فروردین 1393"
```
You can also use a [standard](http://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx) or [custom](http://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.110).aspx) date and time format string, just like you would use with [DateTime.ToString(string)](http://msdn.microsoft.com/en-us/library/zdtaw1bw(v=vs.110).aspx) method.
```C#
new DateTime(2014, 4, 19, 23, 12, 30).ToLocalizedString("MMMM h:mm:ss") => "فروردین 11:12:30 ب.ظ"
```
