# YAML Parser (aka ROS.Net Message Generator)

Use this command line util to build a Message library from ROS Message/Service/Action files.

## Prerequisites

This Console application requires at .Net Core 2.1 (or higher)

## How to use it

In the simplest form use it like

```
cd YAMLParser
dotnet run -- -n "ROS.Messages.my_message_package_msgs" -m "MESSAGES_SOURCE_FOLDER"
```

This command compiles the ROS message files contained in ```MESSAGES_SOURCE_FOLDER``` to an Assembly called ```ROS.Messages.my_message_package_msgs.dll```.

There are some **constraints** to the structure of the messages source folder:
* Messages must be located in a subfolder representing the ROS package name
* The tool looks for *.msg, *.srv and *.action files

All the messages are compiled in the Namespace ```ROS.Messages.<packate_name>```
It is possible, that a messages source folder contains multiple ros packages. In this case YAMLParser creates a namespace for each package in the Assembly.

### Where do I find the generated assembly
YAMLParser generates a .Net project and compiles it. You can find this project in the folder ```../Temp/<PROJECT_NAME>/bin/...```.
The Temp folder is at the same level as the YAMLParser folder.

You can also redirect the output to another folder by specifying the ```-o|--output <OUTPUT_FOLDER>``` option.

### Managing Dependencies
If your messages depend on other ros message packages you have to specify the references.
Use the command line options ```-p|--packages <NUGET_PACKAGE_ID>[/<VERSION>]``` for referencing NuGet packages containing ROS Messages.

```
dotnet run -- -n "ROS.Messages.my_message_package_msgs" -m "MESSAGES_SOURCE_FOLDER" -p "ROS.Messages.common_msgs" -p "ROS.Messages.control_msgs/0.0.1"
```
This command references the NuGet packages

* ROS.Messages.common_msgs [latest]
* ROS.Messages.control_msgs [0.0.1]

to your generated ```ROS.Messages.my_message_package_msgs```. You can specify a version by adding a '/' followed by the version number to the package. If you do not specify a version, the latest available is fetched.

Search for ROS.Messages on our NuGet feed (http://robv005:33333/) to get a list of all available Packages.


#### Other ways to manage dependencies
There are other ways, to state your dependencies. However none of them is reccomended, because it makes dependency management very hard.
The first option is to specify direct .dll references with the ```-a|--assemblies <PATH_TO_DLL>``` flag.
The second one is to add the missing message packages to your message source folder. Be aware that this could lead to naming conflicts, if the using porject also references to an other package containing the same name.

### Building NuGet Packages
YAMLParser also creates a NuGet Package for your assembly, containing all references (package or assembly) to make dependency management easy.
By default your Assembly and the NuGet Package are built with version 1.0.0.

You can change the version by adding the  ```-v|--version <VERSION>``` flag.

```
dotnet run -- -n "ROS.Messages.my_message_package_msgs" -v 1.0.2 -m "MESSAGES_SOURCE_FOLDER" -p "ROS.Messages.common_msgs" -p "ROS.Messages.control_msgs/0.0.1"
```

You can than push the created NuGet package to out NuGet server. See http://robv005:33333/upload for help.

### What else can I do
Use the ```-? | -h | --help```flag to get a list of all supported commands.


## When you get stuck
**Q: YAMLParser runs in an loop and does not generate my assembly**

This happens, if the program cannot resolve all message dependencies. Analyze the debug messages and include the missing message packages to resolve this issue.
