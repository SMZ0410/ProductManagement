﻿using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的常规信息是通过以下项进行控制的
// 控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("ProductManagementUI")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("ProductManagementUI")]
[assembly: AssemblyCopyright("版权所有(C)  2020")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 将使此程序集中的类型
// 对 COM 组件不可见。如果需要
// 从 COM 访问此程序集中的某个类型，请针对该类型将 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于 typelib 的 ID
[assembly: Guid("42793f96-b88a-4ea6-87f0-c7a3619089d1")]

// 程序集的版本信息由下列四个值组成:
//
//      主版本
//      次版本
//      内部版本号
//      修订版本
//
// 你可以指定所有值，也可以让修订版本和内部版本号采用默认值，
// 方法是按如下所示使用 "*":
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
//开关日志记录的操作
//Watch= true是必须的，否则程序就不会对这个进行监听./
[assembly: log4net.Config.XmlConfigurator(Watch = true)]