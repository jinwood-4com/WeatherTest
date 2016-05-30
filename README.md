# 4Com WeatherTest

This is my solution for 4Com's weather test.

As I am applying for a C# position, I chose to build this using C# / MVC to demonstrate my C# skills. However if this was a project that was to be used in a production environment, I would have used a javascript framework such as react or angular and avoided writing any server code.

###Possible further enhancements

* Implement weather results caching. Depending on the frequency of the weather api data changing, cache responses to avoid unnecessary api calls if the data hasn't changed.
* Implement pipeline pattern to handle calling apis. This would enable use of more varied apis and provide a way to aggregate more complex results. Ie precipitation or air pressure.
