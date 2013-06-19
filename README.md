# hVostt.Web.Mvc

ASP.NET MVC 4 Useful Extensions

## Extensions

### EnumExtensions

#### extensions

```c#
DisplayAttribute Display(this Enum value)
string Display(this Enum value, Func<DisplayAttribute, string> attr)
string Display(this Enum value, Func<DisplayAttribute, string> attr, string noAttr)
string DisplayName(this Enum value)
string DisplayDescription(this Enum value)
string DisplayShortName(this Enum value)
IEnumerable<SelectListItem> ToSelectList(this Enum value)
IEnumerable<SelectListItem> ToMultiSelectList(this Enum value)
```

#### methods

```c#
DisplayAttribute Display(Type type, Enum value)
DisplayAttribute Display(Type type, string value)
DisplayAttribute Display<T>(Enum value)
DisplayAttribute Display<T>(string value)
IList<SelectListItem> GetSelectList<T>()
IList<SelectListItem> GetSelectList(Enum value)
IList<SelectListItem> GetMultiSelectList(Enum value)
IList<SelectListItem> GetMultiSelectList<T>(Enum value)
IList<SelectListItem> GetMultiSelectList<T>(IEnumerable<T> values)
IList<SelectListItem> GetSelectList(Type type)
IList<SelectListItem> GetSelectList(Type type, Enum value)
IList<SelectListItem> GetMultiSelectList(Type type, Enum value)
IList<SelectListItem> GetMultiSelectList(Type type, IEnumerable<Enum> values)
```

### LINQ Extensions

```c#
IEnumerable<T[]> SubArrays<T>(this IEnumerable<T> input, int size)
```

### NumeralExtensions

```c#
string ToPriceString(this decimal d, string zero = "")
IHtmlString ToPrice(this decimal d, string zero = "")
string ToRawString(this decimal d)
string ToRawString(this int i)
IHtmlString ToRaw(this decimal d)
IHtmlString ToRaw(this int i)
```

### StringExtensions

```c#
IHtmlString ToRaw(this string str)
string F(this string format, object arg0)
string F(this string format, params object[] args)
string F(this string format, IFormatProvider provider, params object[] args)
string F(this string format, object arg0, object arg1)
string F(this string format, object arg0, object arg1, object arg2)
```

### ViewContextExtensions

```c#
string GetActionName(this ViewContext viewContext)
string GetControllerName(this ViewContext viewContext)
bool IsCurrent(this ViewContext viewContext, string action, string controller)
```

### WebViewPageExtensions

```c#
TimeZoneManager GetTimeZoneManager(this WebViewPage page)
DateTime FromUtc(this WebViewPage page, DateTime dateTime)
DateTime? FromUtc(this WebViewPage page, DateTime? dateTime)
void RedefineSection(this WebPageBase page, string sectionName)
void RedefineSection(this WebPageBase page, params string[] sectionNames)
```

### ViewDataExtensions

```c#
T Set<T>(this ViewDataDictionary viewData, T obj)
T Set<T>(this ViewDataDictionary viewData, T obj, bool fullName)
T Get<T>(this ViewDataDictionary viewData)
T Get<T>(this ViewDataDictionary viewData, bool fullName)
bool Has<T>(this ViewDataDictionary viewData)
bool Has<T>(this ViewDataDictionary viewData, bool fullName)
bool Has(this ViewDataDictionary viewData, string key)
bool Flag(this ViewDataDictionary viewData, string key)
T As<T>(this ViewDataDictionary viewData, string key)
IList<T> AsList<T>(this ViewDataDictionary viewData, string key)
IEnumerable<T> AsEnumerable<T>(this ViewDataDictionary viewData, string key)
IEnumerable<SelectListItem> AsSelectList(this ViewDataDictionary viewData, string key)
string SetTitle(this ViewDataDictionary viewData, string title)
string SetTitle(this ViewDataDictionary viewData, string title, string subTitle)
string GetTitle(this ViewDataDictionary viewData)
string GetSubTitle(this ViewDataDictionary viewData)
```

### ControllerExtensions

```c#
void SetCurrentTimeZone(this Controller controller, TimeZoneInfo timeZone)
TimeZoneInfo GetCurrentTimeZone(this Controller controller)
DateTime FromUtc(this Controller controller, DateTime dateTime)
DateTime? FromUtc(this Controller controller, DateTime? dateTime)
```

## Helpers

### MetaTagHelpers

```c#
MetaBuilder Meta(this HtmlHelper html)
IHtmlString MetaPartial(this HtmlHelper html)
```

#### MetaBuilder

```c#
  public class MetaBuilder : IHtmlString
	{
		MetaBuilder Add(string name, string content, string lang = null);
		MetaBuilder Equiv(string name, string content);
		MetaBuilder Author(string author, string lang = null);
		MetaBuilder Copyright(string copyright, string lang = null);
		MetaBuilder Description(string description, string lang = null);
		MetaBuilder DocumentState(DocumentState documentState);
		MetaBuilder Generator(string generator);
		MetaBuilder Keywords(string keywords, string lang = null);
		MetaBuilder ResourceType(string resourceType);
		MetaBuilder Revisit(int days);
		MetaBuilder Robots(bool index, bool follow, bool shorten = true);
		MetaBuilder Subject(string subject, string lang = null);
		MetaBuilder ContentLanguage(string language);
		MetaBuilder ContentScriptType(string scriptType);
		MetaBuilder ContentStyleType(string styleType);
		MetaBuilder ContentType(string contentType);
		MetaBuilder Expires(DateTime expires);
		MetaBuilder PicsLabel(string label);
		MetaBuilder Pragma(bool noCache);
		MetaBuilder Refresh(string refresh);
		MetaBuilder SetCookie(string cookie);
		MetaBuilder WindowTarget(string target);
		MetaBuilder Imagetoolbar(bool yes);
	}
```

#### example using:

```c#
  @Html.Meta().Author("Me").Keywords("programming developing mvc asp.net").Generator("hands")
```

## Js

```c#
  public class Js
  {
		static readonly IHtmlString Void = new HtmlString("javascript:void(0)");
		static readonly IHtmlString Back = new HtmlString("javascript:history.back();");
  }
```

#### example using

```html
<a href="@Js.Void" onclick="doSomething();">Click me!</a>
```

## TimeZoneManager

```c#
public class TimeZoneManager
{
	static string SessionKey = "TimeZone";

	TimeZoneManager();
	TimeZoneManager(HttpSessionStateBase session);
	TimeZoneManager(HttpSessionState session);
	TimeZoneManager(TimeZoneInfo timeZoneInfo);

	TimeZoneInfo Current { get; }

	DateTime FromUtc(DateTime dateTime);
	DateTime? FromUtc(DateTime? dateTime);
	DateTime ToUtc(DateTime dateTime);
	DateTime? ToUtc(DateTime? dateTime);

	static void SetCurrent(HttpSessionStateBase session, TimeZoneInfo timeZoneInfo);
	static void SetCurrent(HttpSessionState session, TimeZoneInfo timeZoneInfo);
	static TimeZoneInfo GetCurrent(HttpSessionStateBase session);
	static TimeZoneInfo GetCurrent(HttpSessionState session);
}
```

## Exceptions

* NotFoundHttpException()
* NotFoundHttpException(string message)


***

have fun ;)
