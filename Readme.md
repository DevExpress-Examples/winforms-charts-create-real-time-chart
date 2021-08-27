<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/272649173/20.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T899929)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/RealTimeChartUpdates/Form1.cs) (VB: [Form1.vb](./VB/RealTimeChartUpdates/Form1.vb))
<!-- default file list end -->

# How to: Create a Real-Time Chart

The chart processes points that are within its viewport. In this example, points that are beyond the viewport are removed from the data source &#0045; starting from the beginning of the collection. 

This example shows how to generate a new data point that is added to the chart each time the **Timer.Tick** event occurs (every 100 milliseconds). The example uses an [ObservableCollection](https://docs.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1) as the data source for a [series](https://docs.devexpress.com/WindowsForms/6167/controls-and-libraries/chart-control/chart-elements/series?p=netframework). **ObservableCollection** notifies the chart about new items, and the chart is rendered again.
