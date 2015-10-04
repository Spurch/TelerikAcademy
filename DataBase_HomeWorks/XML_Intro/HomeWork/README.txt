1. XML is a language with well defined, structurized(tag based) syntax that is used to describe 
other languages in a ordered/descriptive way. Using the XML notation give us the possibility to store 
not only data but data + meta data. XML is a humanly-readble language which makes it easy to understand
and read but is otherwise rather big, slow and not the best choice for many cases. 

3. Namespaces in XML are used to uniquely identify different elements in a given XML file or schema. 
The need of namespaces in the XML comes because we can have XML files containing tags with equal 
names but different sources (or dictionaries sort of). We might have a XML table with two elements
both named "details" but coming from different program modules. In this situation the XML parser 
has no way of telling the difference between them. By specifying namespaces we can uniquely identify
each on of the "details" elements by simply adding "module1:details" and "module2:details".
We can say that the behaviour of the XML namespaces is similar to that of the .NET namespaces - in each
case we have "uniquely defined vocabulary spaces".