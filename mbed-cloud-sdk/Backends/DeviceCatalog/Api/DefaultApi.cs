using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using device_catalog.Client;
using device_catalog.Model;

namespace device_catalog.Api
{
    
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDefaultApi
    {
        #region Synchronous Operations
        
        /// <summary>
        /// Create device
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Create device&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>DeviceSerializer</returns>
        DeviceSerializer DeviceCreate ();
  
        /// <summary>
        /// Create device
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Create device&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of DeviceSerializer</returns>
        ApiResponse<DeviceSerializer> DeviceCreateWithHttpInfo ();
        
        /// <summary>
        /// Delete device
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Delete device&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId"></param>
        /// <returns>DeviceSerializer</returns>
        DeviceSerializer DeviceDestroy (string deviceId);
  
        /// <summary>
        /// Delete device
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Delete device&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId"></param>
        /// <returns>ApiResponse of DeviceSerializer</returns>
        ApiResponse<DeviceSerializer> DeviceDestroyWithHttpInfo (string deviceId);
        
        /// <summary>
        /// List all update devices
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;List all update devices. The result is paged into pages of 100.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="autoUpdate"> (optional)</param>
        /// <param name="bootstrappedTimestamp"> (optional)</param>
        /// <param name="deployedState"> (optional)</param>
        /// <param name="deployment"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="manifest"> (optional)</param>
        /// <param name="mechanism"> (optional)</param>
        /// <param name="mechanismUrl"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="provisionKey"> (optional)</param>
        /// <param name="serialNumber"> (optional)</param>
        /// <param name="state"> (optional)</param>
        /// <param name="trustClass"> (optional)</param>
        /// <param name="trustLevel"> (optional)</param>
        /// <param name="vendorId"> (optional)</param>
        /// <returns>List&lt;DeviceSerializer&gt;</returns>
        List<DeviceSerializer> DeviceList (string createdAt = null, string updatedAt = null, string autoUpdate = null, string bootstrappedTimestamp = null, string deployedState = null, string deployment = null, string description = null, string deviceClass = null, string deviceId = null, string etag = null, string manifest = null, string mechanism = null, string mechanismUrl = null, string name = null, string _object = null, string provisionKey = null, string serialNumber = null, string state = null, string trustClass = null, string trustLevel = null, string vendorId = null);
  
        /// <summary>
        /// List all update devices
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;List all update devices. The result is paged into pages of 100.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="autoUpdate"> (optional)</param>
        /// <param name="bootstrappedTimestamp"> (optional)</param>
        /// <param name="deployedState"> (optional)</param>
        /// <param name="deployment"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="manifest"> (optional)</param>
        /// <param name="mechanism"> (optional)</param>
        /// <param name="mechanismUrl"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="provisionKey"> (optional)</param>
        /// <param name="serialNumber"> (optional)</param>
        /// <param name="state"> (optional)</param>
        /// <param name="trustClass"> (optional)</param>
        /// <param name="trustLevel"> (optional)</param>
        /// <param name="vendorId"> (optional)</param>
        /// <returns>ApiResponse of List&lt;DeviceSerializer&gt;</returns>
        ApiResponse<List<DeviceSerializer>> DeviceListWithHttpInfo (string createdAt = null, string updatedAt = null, string autoUpdate = null, string bootstrappedTimestamp = null, string deployedState = null, string deployment = null, string description = null, string deviceClass = null, string deviceId = null, string etag = null, string manifest = null, string mechanism = null, string mechanismUrl = null, string name = null, string _object = null, string provisionKey = null, string serialNumber = null, string state = null, string trustClass = null, string trustLevel = null, string vendorId = null);
        
        /// <summary>
        /// The APIs for creating and manipulating devices
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dateTime"></param>
        /// <param name="deviceLogId"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <param name="dateTime2"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId2"> (optional)</param>
        /// <param name="eventType2"> (optional)</param>
        /// <param name="stateChange2"> (optional)</param>
        /// <returns>DeviceLogSerializer</returns>
        DeviceLogSerializer DeviceLogCreate (DateTime? dateTime, string deviceLogId = null, string eventType = null, bool? stateChange = null, string dateTime2 = null, string deviceId = null, string deviceLogId2 = null, string eventType2 = null, string stateChange2 = null);
  
        /// <summary>
        /// The APIs for creating and manipulating devices
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dateTime"></param>
        /// <param name="deviceLogId"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <param name="dateTime2"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId2"> (optional)</param>
        /// <param name="eventType2"> (optional)</param>
        /// <param name="stateChange2"> (optional)</param>
        /// <returns>ApiResponse of DeviceLogSerializer</returns>
        ApiResponse<DeviceLogSerializer> DeviceLogCreateWithHttpInfo (DateTime? dateTime, string deviceLogId = null, string eventType = null, bool? stateChange = null, string dateTime2 = null, string deviceId = null, string deviceLogId2 = null, string eventType2 = null, string stateChange2 = null);
        
        /// <summary>
        /// The APIs for creating and manipulating devices
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param>
        /// <param name="dateTime"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId2"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <returns>DeviceLogSerializer</returns>
        DeviceLogSerializer DeviceLogDestroy (string deviceLogId, string dateTime = null, string deviceId = null, string deviceLogId2 = null, string eventType = null, string stateChange = null);
  
        /// <summary>
        /// The APIs for creating and manipulating devices
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param>
        /// <param name="dateTime"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId2"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <returns>ApiResponse of DeviceLogSerializer</returns>
        ApiResponse<DeviceLogSerializer> DeviceLogDestroyWithHttpInfo (string deviceLogId, string dateTime = null, string deviceId = null, string deviceLogId2 = null, string eventType = null, string stateChange = null);
        
        /// <summary>
        /// List all device logs
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;List all device logs.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dateTime"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <returns>List&lt;DeviceLogSerializer&gt;</returns>
        List<DeviceLogSerializer> DeviceLogList (string dateTime = null, string deviceId = null, string deviceLogId = null, string eventType = null, string stateChange = null);
  
        /// <summary>
        /// List all device logs
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;List all device logs.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dateTime"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <returns>ApiResponse of List&lt;DeviceLogSerializer&gt;</returns>
        ApiResponse<List<DeviceLogSerializer>> DeviceLogListWithHttpInfo (string dateTime = null, string deviceId = null, string deviceLogId = null, string eventType = null, string stateChange = null);
        
        /// <summary>
        /// The APIs for creating and manipulating devices
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param>
        /// <param name="dateTime"> (optional)</param>
        /// <param name="deviceLogId2"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <param name="dateTime2"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId3"> (optional)</param>
        /// <param name="eventType2"> (optional)</param>
        /// <param name="stateChange2"> (optional)</param>
        /// <returns>DeviceLogSerializer</returns>
        DeviceLogSerializer DeviceLogPartialUpdate (string deviceLogId, DateTime? dateTime = null, string deviceLogId2 = null, string eventType = null, bool? stateChange = null, string dateTime2 = null, string deviceId = null, string deviceLogId3 = null, string eventType2 = null, string stateChange2 = null);
  
        /// <summary>
        /// The APIs for creating and manipulating devices
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param>
        /// <param name="dateTime"> (optional)</param>
        /// <param name="deviceLogId2"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <param name="dateTime2"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId3"> (optional)</param>
        /// <param name="eventType2"> (optional)</param>
        /// <param name="stateChange2"> (optional)</param>
        /// <returns>ApiResponse of DeviceLogSerializer</returns>
        ApiResponse<DeviceLogSerializer> DeviceLogPartialUpdateWithHttpInfo (string deviceLogId, DateTime? dateTime = null, string deviceLogId2 = null, string eventType = null, bool? stateChange = null, string dateTime2 = null, string deviceId = null, string deviceLogId3 = null, string eventType2 = null, string stateChange2 = null);
        
        /// <summary>
        /// Retrieve device log
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Retrieve device log.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param>
        /// <returns>DeviceLogSerializer</returns>
        DeviceLogSerializer DeviceLogRetrieve (string deviceLogId);
  
        /// <summary>
        /// Retrieve device log
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Retrieve device log.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param>
        /// <returns>ApiResponse of DeviceLogSerializer</returns>
        ApiResponse<DeviceLogSerializer> DeviceLogRetrieveWithHttpInfo (string deviceLogId);
        
        /// <summary>
        /// The APIs for creating and manipulating devices
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param>
        /// <param name="dateTime"></param>
        /// <param name="deviceLogId2"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <param name="dateTime2"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId3"> (optional)</param>
        /// <param name="eventType2"> (optional)</param>
        /// <param name="stateChange2"> (optional)</param>
        /// <returns>DeviceLogSerializer</returns>
        DeviceLogSerializer DeviceLogUpdate (string deviceLogId, DateTime? dateTime, string deviceLogId2 = null, string eventType = null, bool? stateChange = null, string dateTime2 = null, string deviceId = null, string deviceLogId3 = null, string eventType2 = null, string stateChange2 = null);
  
        /// <summary>
        /// The APIs for creating and manipulating devices
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param>
        /// <param name="dateTime"></param>
        /// <param name="deviceLogId2"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <param name="dateTime2"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId3"> (optional)</param>
        /// <param name="eventType2"> (optional)</param>
        /// <param name="stateChange2"> (optional)</param>
        /// <returns>ApiResponse of DeviceLogSerializer</returns>
        ApiResponse<DeviceLogSerializer> DeviceLogUpdateWithHttpInfo (string deviceLogId, DateTime? dateTime, string deviceLogId2 = null, string eventType = null, bool? stateChange = null, string dateTime2 = null, string deviceId = null, string deviceLogId3 = null, string eventType2 = null, string stateChange2 = null);
        
        /// <summary>
        /// Update device fields
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Update device fields&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId">The ID of the device</param>
        /// <returns>DeviceSerializer</returns>
        DeviceSerializer DevicePartialUpdate (string deviceId);
  
        /// <summary>
        /// Update device fields
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Update device fields&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId">The ID of the device</param>
        /// <returns>ApiResponse of DeviceSerializer</returns>
        ApiResponse<DeviceSerializer> DevicePartialUpdateWithHttpInfo (string deviceId);
        
        /// <summary>
        /// Retrieve device
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Retrieve device.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId"></param>
        /// <returns>DeviceSerializer</returns>
        DeviceSerializer DeviceRetrieve (string deviceId);
  
        /// <summary>
        /// Retrieve device
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Retrieve device.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId"></param>
        /// <returns>ApiResponse of DeviceSerializer</returns>
        ApiResponse<DeviceSerializer> DeviceRetrieveWithHttpInfo (string deviceId);
        
        /// <summary>
        /// Update device
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Update device.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId">The ID of the device</param>
        /// <returns>DeviceSerializer</returns>
        DeviceSerializer DeviceUpdate (string deviceId);
  
        /// <summary>
        /// Update device
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Update device.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId">The ID of the device</param>
        /// <returns>ApiResponse of DeviceSerializer</returns>
        ApiResponse<DeviceSerializer> DeviceUpdateWithHttpInfo (string deviceId);
        
        #endregion Synchronous Operations
        
        #region Asynchronous Operations
        
        /// <summary>
        /// Create device
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Create device&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of DeviceSerializer</returns>
        System.Threading.Tasks.Task<DeviceSerializer> DeviceCreateAsync ();

        /// <summary>
        /// Create device
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Create device&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (DeviceSerializer)</returns>
        System.Threading.Tasks.Task<ApiResponse<DeviceSerializer>> DeviceCreateAsyncWithHttpInfo ();
        
        /// <summary>
        /// Delete device
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Delete device&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId"></param>
        /// <returns>Task of DeviceSerializer</returns>
        System.Threading.Tasks.Task<DeviceSerializer> DeviceDestroyAsync (string deviceId);

        /// <summary>
        /// Delete device
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Delete device&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId"></param>
        /// <returns>Task of ApiResponse (DeviceSerializer)</returns>
        System.Threading.Tasks.Task<ApiResponse<DeviceSerializer>> DeviceDestroyAsyncWithHttpInfo (string deviceId);
        
        /// <summary>
        /// List all update devices
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;List all update devices. The result is paged into pages of 100.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="autoUpdate"> (optional)</param>
        /// <param name="bootstrappedTimestamp"> (optional)</param>
        /// <param name="deployedState"> (optional)</param>
        /// <param name="deployment"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="manifest"> (optional)</param>
        /// <param name="mechanism"> (optional)</param>
        /// <param name="mechanismUrl"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="provisionKey"> (optional)</param>
        /// <param name="serialNumber"> (optional)</param>
        /// <param name="state"> (optional)</param>
        /// <param name="trustClass"> (optional)</param>
        /// <param name="trustLevel"> (optional)</param>
        /// <param name="vendorId"> (optional)</param>
        /// <returns>Task of List&lt;DeviceSerializer&gt;</returns>
        System.Threading.Tasks.Task<List<DeviceSerializer>> DeviceListAsync (string createdAt = null, string updatedAt = null, string autoUpdate = null, string bootstrappedTimestamp = null, string deployedState = null, string deployment = null, string description = null, string deviceClass = null, string deviceId = null, string etag = null, string manifest = null, string mechanism = null, string mechanismUrl = null, string name = null, string _object = null, string provisionKey = null, string serialNumber = null, string state = null, string trustClass = null, string trustLevel = null, string vendorId = null);

        /// <summary>
        /// List all update devices
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;List all update devices. The result is paged into pages of 100.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="autoUpdate"> (optional)</param>
        /// <param name="bootstrappedTimestamp"> (optional)</param>
        /// <param name="deployedState"> (optional)</param>
        /// <param name="deployment"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="manifest"> (optional)</param>
        /// <param name="mechanism"> (optional)</param>
        /// <param name="mechanismUrl"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="provisionKey"> (optional)</param>
        /// <param name="serialNumber"> (optional)</param>
        /// <param name="state"> (optional)</param>
        /// <param name="trustClass"> (optional)</param>
        /// <param name="trustLevel"> (optional)</param>
        /// <param name="vendorId"> (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;DeviceSerializer&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<DeviceSerializer>>> DeviceListAsyncWithHttpInfo (string createdAt = null, string updatedAt = null, string autoUpdate = null, string bootstrappedTimestamp = null, string deployedState = null, string deployment = null, string description = null, string deviceClass = null, string deviceId = null, string etag = null, string manifest = null, string mechanism = null, string mechanismUrl = null, string name = null, string _object = null, string provisionKey = null, string serialNumber = null, string state = null, string trustClass = null, string trustLevel = null, string vendorId = null);
        
        /// <summary>
        /// The APIs for creating and manipulating devices
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dateTime"></param>
        /// <param name="deviceLogId"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <param name="dateTime2"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId2"> (optional)</param>
        /// <param name="eventType2"> (optional)</param>
        /// <param name="stateChange2"> (optional)</param>
        /// <returns>Task of DeviceLogSerializer</returns>
        System.Threading.Tasks.Task<DeviceLogSerializer> DeviceLogCreateAsync (DateTime? dateTime, string deviceLogId = null, string eventType = null, bool? stateChange = null, string dateTime2 = null, string deviceId = null, string deviceLogId2 = null, string eventType2 = null, string stateChange2 = null);

        /// <summary>
        /// The APIs for creating and manipulating devices
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dateTime"></param>
        /// <param name="deviceLogId"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <param name="dateTime2"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId2"> (optional)</param>
        /// <param name="eventType2"> (optional)</param>
        /// <param name="stateChange2"> (optional)</param>
        /// <returns>Task of ApiResponse (DeviceLogSerializer)</returns>
        System.Threading.Tasks.Task<ApiResponse<DeviceLogSerializer>> DeviceLogCreateAsyncWithHttpInfo (DateTime? dateTime, string deviceLogId = null, string eventType = null, bool? stateChange = null, string dateTime2 = null, string deviceId = null, string deviceLogId2 = null, string eventType2 = null, string stateChange2 = null);
        
        /// <summary>
        /// The APIs for creating and manipulating devices
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param>
        /// <param name="dateTime"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId2"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <returns>Task of DeviceLogSerializer</returns>
        System.Threading.Tasks.Task<DeviceLogSerializer> DeviceLogDestroyAsync (string deviceLogId, string dateTime = null, string deviceId = null, string deviceLogId2 = null, string eventType = null, string stateChange = null);

        /// <summary>
        /// The APIs for creating and manipulating devices
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param>
        /// <param name="dateTime"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId2"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <returns>Task of ApiResponse (DeviceLogSerializer)</returns>
        System.Threading.Tasks.Task<ApiResponse<DeviceLogSerializer>> DeviceLogDestroyAsyncWithHttpInfo (string deviceLogId, string dateTime = null, string deviceId = null, string deviceLogId2 = null, string eventType = null, string stateChange = null);
        
        /// <summary>
        /// List all device logs
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;List all device logs.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dateTime"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <returns>Task of List&lt;DeviceLogSerializer&gt;</returns>
        System.Threading.Tasks.Task<List<DeviceLogSerializer>> DeviceLogListAsync (string dateTime = null, string deviceId = null, string deviceLogId = null, string eventType = null, string stateChange = null);

        /// <summary>
        /// List all device logs
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;List all device logs.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dateTime"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;DeviceLogSerializer&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<DeviceLogSerializer>>> DeviceLogListAsyncWithHttpInfo (string dateTime = null, string deviceId = null, string deviceLogId = null, string eventType = null, string stateChange = null);
        
        /// <summary>
        /// The APIs for creating and manipulating devices
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param>
        /// <param name="dateTime"> (optional)</param>
        /// <param name="deviceLogId2"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <param name="dateTime2"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId3"> (optional)</param>
        /// <param name="eventType2"> (optional)</param>
        /// <param name="stateChange2"> (optional)</param>
        /// <returns>Task of DeviceLogSerializer</returns>
        System.Threading.Tasks.Task<DeviceLogSerializer> DeviceLogPartialUpdateAsync (string deviceLogId, DateTime? dateTime = null, string deviceLogId2 = null, string eventType = null, bool? stateChange = null, string dateTime2 = null, string deviceId = null, string deviceLogId3 = null, string eventType2 = null, string stateChange2 = null);

        /// <summary>
        /// The APIs for creating and manipulating devices
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param>
        /// <param name="dateTime"> (optional)</param>
        /// <param name="deviceLogId2"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <param name="dateTime2"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId3"> (optional)</param>
        /// <param name="eventType2"> (optional)</param>
        /// <param name="stateChange2"> (optional)</param>
        /// <returns>Task of ApiResponse (DeviceLogSerializer)</returns>
        System.Threading.Tasks.Task<ApiResponse<DeviceLogSerializer>> DeviceLogPartialUpdateAsyncWithHttpInfo (string deviceLogId, DateTime? dateTime = null, string deviceLogId2 = null, string eventType = null, bool? stateChange = null, string dateTime2 = null, string deviceId = null, string deviceLogId3 = null, string eventType2 = null, string stateChange2 = null);
        
        /// <summary>
        /// Retrieve device log
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Retrieve device log.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param>
        /// <returns>Task of DeviceLogSerializer</returns>
        System.Threading.Tasks.Task<DeviceLogSerializer> DeviceLogRetrieveAsync (string deviceLogId);

        /// <summary>
        /// Retrieve device log
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Retrieve device log.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param>
        /// <returns>Task of ApiResponse (DeviceLogSerializer)</returns>
        System.Threading.Tasks.Task<ApiResponse<DeviceLogSerializer>> DeviceLogRetrieveAsyncWithHttpInfo (string deviceLogId);
        
        /// <summary>
        /// The APIs for creating and manipulating devices
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param>
        /// <param name="dateTime"></param>
        /// <param name="deviceLogId2"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <param name="dateTime2"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId3"> (optional)</param>
        /// <param name="eventType2"> (optional)</param>
        /// <param name="stateChange2"> (optional)</param>
        /// <returns>Task of DeviceLogSerializer</returns>
        System.Threading.Tasks.Task<DeviceLogSerializer> DeviceLogUpdateAsync (string deviceLogId, DateTime? dateTime, string deviceLogId2 = null, string eventType = null, bool? stateChange = null, string dateTime2 = null, string deviceId = null, string deviceLogId3 = null, string eventType2 = null, string stateChange2 = null);

        /// <summary>
        /// The APIs for creating and manipulating devices
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param>
        /// <param name="dateTime"></param>
        /// <param name="deviceLogId2"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <param name="dateTime2"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId3"> (optional)</param>
        /// <param name="eventType2"> (optional)</param>
        /// <param name="stateChange2"> (optional)</param>
        /// <returns>Task of ApiResponse (DeviceLogSerializer)</returns>
        System.Threading.Tasks.Task<ApiResponse<DeviceLogSerializer>> DeviceLogUpdateAsyncWithHttpInfo (string deviceLogId, DateTime? dateTime, string deviceLogId2 = null, string eventType = null, bool? stateChange = null, string dateTime2 = null, string deviceId = null, string deviceLogId3 = null, string eventType2 = null, string stateChange2 = null);
        
        /// <summary>
        /// Update device fields
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Update device fields&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId">The ID of the device</param>
        /// <returns>Task of DeviceSerializer</returns>
        System.Threading.Tasks.Task<DeviceSerializer> DevicePartialUpdateAsync (string deviceId);

        /// <summary>
        /// Update device fields
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Update device fields&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId">The ID of the device</param>
        /// <returns>Task of ApiResponse (DeviceSerializer)</returns>
        System.Threading.Tasks.Task<ApiResponse<DeviceSerializer>> DevicePartialUpdateAsyncWithHttpInfo (string deviceId);
        
        /// <summary>
        /// Retrieve device
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Retrieve device.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId"></param>
        /// <returns>Task of DeviceSerializer</returns>
        System.Threading.Tasks.Task<DeviceSerializer> DeviceRetrieveAsync (string deviceId);

        /// <summary>
        /// Retrieve device
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Retrieve device.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId"></param>
        /// <returns>Task of ApiResponse (DeviceSerializer)</returns>
        System.Threading.Tasks.Task<ApiResponse<DeviceSerializer>> DeviceRetrieveAsyncWithHttpInfo (string deviceId);
        
        /// <summary>
        /// Update device
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Update device.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId">The ID of the device</param>
        /// <returns>Task of DeviceSerializer</returns>
        System.Threading.Tasks.Task<DeviceSerializer> DeviceUpdateAsync (string deviceId);

        /// <summary>
        /// Update device
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Update device.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId">The ID of the device</param>
        /// <returns>Task of ApiResponse (DeviceSerializer)</returns>
        System.Threading.Tasks.Task<ApiResponse<DeviceSerializer>> DeviceUpdateAsyncWithHttpInfo (string deviceId);
        
        #endregion Asynchronous Operations
        
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DefaultApi : IDefaultApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DefaultApi(String basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public DefaultApi(Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = Configuration.Default; 
            else
                this.Configuration = configuration;

            // ensure API client has configuration ready
            if (Configuration.ApiClient.Configuration == null)
            {
                this.Configuration.ApiClient.Configuration = this.Configuration;
            }
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuraiton.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }
    
        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Configuration Configuration {get; set;}

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public Dictionary<String, String> DefaultHeader()
        {
            return this.Configuration.DefaultHeader;
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }
   
        
        /// <summary>
        /// Create device &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Create device&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>DeviceSerializer</returns>
        public DeviceSerializer DeviceCreate ()
        {
             ApiResponse<DeviceSerializer> localVarResponse = DeviceCreateWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Create device &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Create device&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of DeviceSerializer</returns>
        public ApiResponse< DeviceSerializer > DeviceCreateWithHttpInfo ()
        {
            
    
            var localVarPath = "/v3/devices/";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            
            
            
            
            

            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            
    
            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath, 
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DeviceCreate: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DeviceCreate: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<DeviceSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DeviceSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DeviceSerializer)));
            
        }

        
        /// <summary>
        /// Create device &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Create device&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of DeviceSerializer</returns>
        public async System.Threading.Tasks.Task<DeviceSerializer> DeviceCreateAsync ()
        {
             ApiResponse<DeviceSerializer> localVarResponse = await DeviceCreateAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// Create device &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Create device&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (DeviceSerializer)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<DeviceSerializer>> DeviceCreateAsyncWithHttpInfo ()
        {
            
    
            var localVarPath = "/v3/devices/";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            
            
            
            
            

            
            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath, 
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams, 
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DeviceCreate: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DeviceCreate: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<DeviceSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DeviceSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DeviceSerializer)));
            
        }
        
        /// <summary>
        /// Delete device &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Delete device&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId"></param> 
        /// <returns>DeviceSerializer</returns>
        public DeviceSerializer DeviceDestroy (string deviceId)
        {
             ApiResponse<DeviceSerializer> localVarResponse = DeviceDestroyWithHttpInfo(deviceId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Delete device &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Delete device&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId"></param> 
        /// <returns>ApiResponse of DeviceSerializer</returns>
        public ApiResponse< DeviceSerializer > DeviceDestroyWithHttpInfo (string deviceId)
        {
            
            // verify the required parameter 'deviceId' is set
            if (deviceId == null)
                throw new ApiException(400, "Missing required parameter 'deviceId' when calling DefaultApi->DeviceDestroy");
            
    
            var localVarPath = "/v3/devices/{device_id}/";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (deviceId != null) localVarPathParams.Add("device_id", Configuration.ApiClient.ParameterToString(deviceId)); // path parameter
            
            
            
            
            

            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            
    
            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath, 
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DeviceDestroy: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DeviceDestroy: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<DeviceSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DeviceSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DeviceSerializer)));
            
        }

        
        /// <summary>
        /// Delete device &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Delete device&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId"></param>
        /// <returns>Task of DeviceSerializer</returns>
        public async System.Threading.Tasks.Task<DeviceSerializer> DeviceDestroyAsync (string deviceId)
        {
             ApiResponse<DeviceSerializer> localVarResponse = await DeviceDestroyAsyncWithHttpInfo(deviceId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Delete device &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Delete device&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId"></param>
        /// <returns>Task of ApiResponse (DeviceSerializer)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<DeviceSerializer>> DeviceDestroyAsyncWithHttpInfo (string deviceId)
        {
            // verify the required parameter 'deviceId' is set
            if (deviceId == null) throw new ApiException(400, "Missing required parameter 'deviceId' when calling DeviceDestroy");
            
    
            var localVarPath = "/v3/devices/{device_id}/";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (deviceId != null) localVarPathParams.Add("device_id", Configuration.ApiClient.ParameterToString(deviceId)); // path parameter
            
            
            
            
            

            
            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath, 
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams, 
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DeviceDestroy: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DeviceDestroy: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<DeviceSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DeviceSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DeviceSerializer)));
            
        }
        
        /// <summary>
        /// List all update devices &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;List all update devices. The result is paged into pages of 100.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="createdAt"> (optional)</param> 
        /// <param name="updatedAt"> (optional)</param> 
        /// <param name="autoUpdate"> (optional)</param> 
        /// <param name="bootstrappedTimestamp"> (optional)</param> 
        /// <param name="deployedState"> (optional)</param> 
        /// <param name="deployment"> (optional)</param> 
        /// <param name="description"> (optional)</param> 
        /// <param name="deviceClass"> (optional)</param> 
        /// <param name="deviceId"> (optional)</param> 
        /// <param name="etag"> (optional)</param> 
        /// <param name="manifest"> (optional)</param> 
        /// <param name="mechanism"> (optional)</param> 
        /// <param name="mechanismUrl"> (optional)</param> 
        /// <param name="name"> (optional)</param> 
        /// <param name="_object"> (optional)</param> 
        /// <param name="provisionKey"> (optional)</param> 
        /// <param name="serialNumber"> (optional)</param> 
        /// <param name="state"> (optional)</param> 
        /// <param name="trustClass"> (optional)</param> 
        /// <param name="trustLevel"> (optional)</param> 
        /// <param name="vendorId"> (optional)</param> 
        /// <returns>List&lt;DeviceSerializer&gt;</returns>
        public List<DeviceSerializer> DeviceList (string createdAt = null, string updatedAt = null, string autoUpdate = null, string bootstrappedTimestamp = null, string deployedState = null, string deployment = null, string description = null, string deviceClass = null, string deviceId = null, string etag = null, string manifest = null, string mechanism = null, string mechanismUrl = null, string name = null, string _object = null, string provisionKey = null, string serialNumber = null, string state = null, string trustClass = null, string trustLevel = null, string vendorId = null)
        {
             ApiResponse<List<DeviceSerializer>> localVarResponse = DeviceListWithHttpInfo(createdAt, updatedAt, autoUpdate, bootstrappedTimestamp, deployedState, deployment, description, deviceClass, deviceId, etag, manifest, mechanism, mechanismUrl, name, _object, provisionKey, serialNumber, state, trustClass, trustLevel, vendorId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// List all update devices &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;List all update devices. The result is paged into pages of 100.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="createdAt"> (optional)</param> 
        /// <param name="updatedAt"> (optional)</param> 
        /// <param name="autoUpdate"> (optional)</param> 
        /// <param name="bootstrappedTimestamp"> (optional)</param> 
        /// <param name="deployedState"> (optional)</param> 
        /// <param name="deployment"> (optional)</param> 
        /// <param name="description"> (optional)</param> 
        /// <param name="deviceClass"> (optional)</param> 
        /// <param name="deviceId"> (optional)</param> 
        /// <param name="etag"> (optional)</param> 
        /// <param name="manifest"> (optional)</param> 
        /// <param name="mechanism"> (optional)</param> 
        /// <param name="mechanismUrl"> (optional)</param> 
        /// <param name="name"> (optional)</param> 
        /// <param name="_object"> (optional)</param> 
        /// <param name="provisionKey"> (optional)</param> 
        /// <param name="serialNumber"> (optional)</param> 
        /// <param name="state"> (optional)</param> 
        /// <param name="trustClass"> (optional)</param> 
        /// <param name="trustLevel"> (optional)</param> 
        /// <param name="vendorId"> (optional)</param> 
        /// <returns>ApiResponse of List&lt;DeviceSerializer&gt;</returns>
        public ApiResponse< List<DeviceSerializer> > DeviceListWithHttpInfo (string createdAt = null, string updatedAt = null, string autoUpdate = null, string bootstrappedTimestamp = null, string deployedState = null, string deployment = null, string description = null, string deviceClass = null, string deviceId = null, string etag = null, string manifest = null, string mechanism = null, string mechanismUrl = null, string name = null, string _object = null, string provisionKey = null, string serialNumber = null, string state = null, string trustClass = null, string trustLevel = null, string vendorId = null)
        {
            
    
            var localVarPath = "/v3/devices/";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            
            if (createdAt != null) localVarQueryParams.Add("created_at", Configuration.ApiClient.ParameterToString(createdAt)); // query parameter
            if (updatedAt != null) localVarQueryParams.Add("updated_at", Configuration.ApiClient.ParameterToString(updatedAt)); // query parameter
            if (autoUpdate != null) localVarQueryParams.Add("auto_update", Configuration.ApiClient.ParameterToString(autoUpdate)); // query parameter
            if (bootstrappedTimestamp != null) localVarQueryParams.Add("bootstrapped_timestamp", Configuration.ApiClient.ParameterToString(bootstrappedTimestamp)); // query parameter
            if (deployedState != null) localVarQueryParams.Add("deployed_state", Configuration.ApiClient.ParameterToString(deployedState)); // query parameter
            if (deployment != null) localVarQueryParams.Add("deployment", Configuration.ApiClient.ParameterToString(deployment)); // query parameter
            if (description != null) localVarQueryParams.Add("description", Configuration.ApiClient.ParameterToString(description)); // query parameter
            if (deviceClass != null) localVarQueryParams.Add("device_class", Configuration.ApiClient.ParameterToString(deviceClass)); // query parameter
            if (deviceId != null) localVarQueryParams.Add("device_id", Configuration.ApiClient.ParameterToString(deviceId)); // query parameter
            if (etag != null) localVarQueryParams.Add("etag", Configuration.ApiClient.ParameterToString(etag)); // query parameter
            if (manifest != null) localVarQueryParams.Add("manifest", Configuration.ApiClient.ParameterToString(manifest)); // query parameter
            if (mechanism != null) localVarQueryParams.Add("mechanism", Configuration.ApiClient.ParameterToString(mechanism)); // query parameter
            if (mechanismUrl != null) localVarQueryParams.Add("mechanism_url", Configuration.ApiClient.ParameterToString(mechanismUrl)); // query parameter
            if (name != null) localVarQueryParams.Add("name", Configuration.ApiClient.ParameterToString(name)); // query parameter
            if (_object != null) localVarQueryParams.Add("object", Configuration.ApiClient.ParameterToString(_object)); // query parameter
            if (provisionKey != null) localVarQueryParams.Add("provision_key", Configuration.ApiClient.ParameterToString(provisionKey)); // query parameter
            if (serialNumber != null) localVarQueryParams.Add("serial_number", Configuration.ApiClient.ParameterToString(serialNumber)); // query parameter
            if (state != null) localVarQueryParams.Add("state", Configuration.ApiClient.ParameterToString(state)); // query parameter
            if (trustClass != null) localVarQueryParams.Add("trust_class", Configuration.ApiClient.ParameterToString(trustClass)); // query parameter
            if (trustLevel != null) localVarQueryParams.Add("trust_level", Configuration.ApiClient.ParameterToString(trustLevel)); // query parameter
            if (vendorId != null) localVarQueryParams.Add("vendor_id", Configuration.ApiClient.ParameterToString(vendorId)); // query parameter
            
            
            
            

            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            
    
            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath, 
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DeviceList: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DeviceList: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<List<DeviceSerializer>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<DeviceSerializer>) Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<DeviceSerializer>)));
            
        }

        
        /// <summary>
        /// List all update devices &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;List all update devices. The result is paged into pages of 100.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="autoUpdate"> (optional)</param>
        /// <param name="bootstrappedTimestamp"> (optional)</param>
        /// <param name="deployedState"> (optional)</param>
        /// <param name="deployment"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="manifest"> (optional)</param>
        /// <param name="mechanism"> (optional)</param>
        /// <param name="mechanismUrl"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="provisionKey"> (optional)</param>
        /// <param name="serialNumber"> (optional)</param>
        /// <param name="state"> (optional)</param>
        /// <param name="trustClass"> (optional)</param>
        /// <param name="trustLevel"> (optional)</param>
        /// <param name="vendorId"> (optional)</param>
        /// <returns>Task of List&lt;DeviceSerializer&gt;</returns>
        public async System.Threading.Tasks.Task<List<DeviceSerializer>> DeviceListAsync (string createdAt = null, string updatedAt = null, string autoUpdate = null, string bootstrappedTimestamp = null, string deployedState = null, string deployment = null, string description = null, string deviceClass = null, string deviceId = null, string etag = null, string manifest = null, string mechanism = null, string mechanismUrl = null, string name = null, string _object = null, string provisionKey = null, string serialNumber = null, string state = null, string trustClass = null, string trustLevel = null, string vendorId = null)
        {
             ApiResponse<List<DeviceSerializer>> localVarResponse = await DeviceListAsyncWithHttpInfo(createdAt, updatedAt, autoUpdate, bootstrappedTimestamp, deployedState, deployment, description, deviceClass, deviceId, etag, manifest, mechanism, mechanismUrl, name, _object, provisionKey, serialNumber, state, trustClass, trustLevel, vendorId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// List all update devices &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;List all update devices. The result is paged into pages of 100.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="autoUpdate"> (optional)</param>
        /// <param name="bootstrappedTimestamp"> (optional)</param>
        /// <param name="deployedState"> (optional)</param>
        /// <param name="deployment"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="manifest"> (optional)</param>
        /// <param name="mechanism"> (optional)</param>
        /// <param name="mechanismUrl"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="provisionKey"> (optional)</param>
        /// <param name="serialNumber"> (optional)</param>
        /// <param name="state"> (optional)</param>
        /// <param name="trustClass"> (optional)</param>
        /// <param name="trustLevel"> (optional)</param>
        /// <param name="vendorId"> (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;DeviceSerializer&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<DeviceSerializer>>> DeviceListAsyncWithHttpInfo (string createdAt = null, string updatedAt = null, string autoUpdate = null, string bootstrappedTimestamp = null, string deployedState = null, string deployment = null, string description = null, string deviceClass = null, string deviceId = null, string etag = null, string manifest = null, string mechanism = null, string mechanismUrl = null, string name = null, string _object = null, string provisionKey = null, string serialNumber = null, string state = null, string trustClass = null, string trustLevel = null, string vendorId = null)
        {
            
    
            var localVarPath = "/v3/devices/";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            
            if (createdAt != null) localVarQueryParams.Add("created_at", Configuration.ApiClient.ParameterToString(createdAt)); // query parameter
            if (updatedAt != null) localVarQueryParams.Add("updated_at", Configuration.ApiClient.ParameterToString(updatedAt)); // query parameter
            if (autoUpdate != null) localVarQueryParams.Add("auto_update", Configuration.ApiClient.ParameterToString(autoUpdate)); // query parameter
            if (bootstrappedTimestamp != null) localVarQueryParams.Add("bootstrapped_timestamp", Configuration.ApiClient.ParameterToString(bootstrappedTimestamp)); // query parameter
            if (deployedState != null) localVarQueryParams.Add("deployed_state", Configuration.ApiClient.ParameterToString(deployedState)); // query parameter
            if (deployment != null) localVarQueryParams.Add("deployment", Configuration.ApiClient.ParameterToString(deployment)); // query parameter
            if (description != null) localVarQueryParams.Add("description", Configuration.ApiClient.ParameterToString(description)); // query parameter
            if (deviceClass != null) localVarQueryParams.Add("device_class", Configuration.ApiClient.ParameterToString(deviceClass)); // query parameter
            if (deviceId != null) localVarQueryParams.Add("device_id", Configuration.ApiClient.ParameterToString(deviceId)); // query parameter
            if (etag != null) localVarQueryParams.Add("etag", Configuration.ApiClient.ParameterToString(etag)); // query parameter
            if (manifest != null) localVarQueryParams.Add("manifest", Configuration.ApiClient.ParameterToString(manifest)); // query parameter
            if (mechanism != null) localVarQueryParams.Add("mechanism", Configuration.ApiClient.ParameterToString(mechanism)); // query parameter
            if (mechanismUrl != null) localVarQueryParams.Add("mechanism_url", Configuration.ApiClient.ParameterToString(mechanismUrl)); // query parameter
            if (name != null) localVarQueryParams.Add("name", Configuration.ApiClient.ParameterToString(name)); // query parameter
            if (_object != null) localVarQueryParams.Add("object", Configuration.ApiClient.ParameterToString(_object)); // query parameter
            if (provisionKey != null) localVarQueryParams.Add("provision_key", Configuration.ApiClient.ParameterToString(provisionKey)); // query parameter
            if (serialNumber != null) localVarQueryParams.Add("serial_number", Configuration.ApiClient.ParameterToString(serialNumber)); // query parameter
            if (state != null) localVarQueryParams.Add("state", Configuration.ApiClient.ParameterToString(state)); // query parameter
            if (trustClass != null) localVarQueryParams.Add("trust_class", Configuration.ApiClient.ParameterToString(trustClass)); // query parameter
            if (trustLevel != null) localVarQueryParams.Add("trust_level", Configuration.ApiClient.ParameterToString(trustLevel)); // query parameter
            if (vendorId != null) localVarQueryParams.Add("vendor_id", Configuration.ApiClient.ParameterToString(vendorId)); // query parameter
            
            
            
            

            
            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath, 
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams, 
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DeviceList: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DeviceList: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<List<DeviceSerializer>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<DeviceSerializer>) Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<DeviceSerializer>)));
            
        }
        
        /// <summary>
        /// The APIs for creating and manipulating devices &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dateTime"></param> 
        /// <param name="deviceLogId"> (optional)</param> 
        /// <param name="eventType"> (optional)</param> 
        /// <param name="stateChange"> (optional)</param> 
        /// <param name="dateTime2"> (optional)</param> 
        /// <param name="deviceId"> (optional)</param> 
        /// <param name="deviceLogId2"> (optional)</param> 
        /// <param name="eventType2"> (optional)</param> 
        /// <param name="stateChange2"> (optional)</param> 
        /// <returns>DeviceLogSerializer</returns>
        public DeviceLogSerializer DeviceLogCreate (DateTime? dateTime, string deviceLogId = null, string eventType = null, bool? stateChange = null, string dateTime2 = null, string deviceId = null, string deviceLogId2 = null, string eventType2 = null, string stateChange2 = null)
        {
             ApiResponse<DeviceLogSerializer> localVarResponse = DeviceLogCreateWithHttpInfo(dateTime, deviceLogId, eventType, stateChange, dateTime2, deviceId, deviceLogId2, eventType2, stateChange2);
             return localVarResponse.Data;
        }

        /// <summary>
        /// The APIs for creating and manipulating devices &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dateTime"></param> 
        /// <param name="deviceLogId"> (optional)</param> 
        /// <param name="eventType"> (optional)</param> 
        /// <param name="stateChange"> (optional)</param> 
        /// <param name="dateTime2"> (optional)</param> 
        /// <param name="deviceId"> (optional)</param> 
        /// <param name="deviceLogId2"> (optional)</param> 
        /// <param name="eventType2"> (optional)</param> 
        /// <param name="stateChange2"> (optional)</param> 
        /// <returns>ApiResponse of DeviceLogSerializer</returns>
        public ApiResponse< DeviceLogSerializer > DeviceLogCreateWithHttpInfo (DateTime? dateTime, string deviceLogId = null, string eventType = null, bool? stateChange = null, string dateTime2 = null, string deviceId = null, string deviceLogId2 = null, string eventType2 = null, string stateChange2 = null)
        {
            
            // verify the required parameter 'dateTime' is set
            if (dateTime == null)
                throw new ApiException(400, "Missing required parameter 'dateTime' when calling DefaultApi->DeviceLogCreate");
            
    
            var localVarPath = "/v3/devicelog/";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            
            if (dateTime2 != null) localVarQueryParams.Add("date_time", Configuration.ApiClient.ParameterToString(dateTime2)); // query parameter
            if (deviceId != null) localVarQueryParams.Add("device_id", Configuration.ApiClient.ParameterToString(deviceId)); // query parameter
            if (deviceLogId2 != null) localVarQueryParams.Add("device_log_id", Configuration.ApiClient.ParameterToString(deviceLogId2)); // query parameter
            if (eventType2 != null) localVarQueryParams.Add("event_type", Configuration.ApiClient.ParameterToString(eventType2)); // query parameter
            if (stateChange2 != null) localVarQueryParams.Add("state_change", Configuration.ApiClient.ParameterToString(stateChange2)); // query parameter
            
            
            if (dateTime != null) localVarFormParams.Add("date_time", Configuration.ApiClient.ParameterToString(dateTime)); // form parameter
            if (deviceLogId != null) localVarFormParams.Add("device_log_id", Configuration.ApiClient.ParameterToString(deviceLogId)); // form parameter
            if (eventType != null) localVarFormParams.Add("event_type", Configuration.ApiClient.ParameterToString(eventType)); // form parameter
            if (stateChange != null) localVarFormParams.Add("state_change", Configuration.ApiClient.ParameterToString(stateChange)); // form parameter
            
            

            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            
    
            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath, 
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DeviceLogCreate: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DeviceLogCreate: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<DeviceLogSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DeviceLogSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DeviceLogSerializer)));
            
        }

        
        /// <summary>
        /// The APIs for creating and manipulating devices &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dateTime"></param>
        /// <param name="deviceLogId"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <param name="dateTime2"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId2"> (optional)</param>
        /// <param name="eventType2"> (optional)</param>
        /// <param name="stateChange2"> (optional)</param>
        /// <returns>Task of DeviceLogSerializer</returns>
        public async System.Threading.Tasks.Task<DeviceLogSerializer> DeviceLogCreateAsync (DateTime? dateTime, string deviceLogId = null, string eventType = null, bool? stateChange = null, string dateTime2 = null, string deviceId = null, string deviceLogId2 = null, string eventType2 = null, string stateChange2 = null)
        {
             ApiResponse<DeviceLogSerializer> localVarResponse = await DeviceLogCreateAsyncWithHttpInfo(dateTime, deviceLogId, eventType, stateChange, dateTime2, deviceId, deviceLogId2, eventType2, stateChange2);
             return localVarResponse.Data;

        }

        /// <summary>
        /// The APIs for creating and manipulating devices &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dateTime"></param>
        /// <param name="deviceLogId"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <param name="dateTime2"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId2"> (optional)</param>
        /// <param name="eventType2"> (optional)</param>
        /// <param name="stateChange2"> (optional)</param>
        /// <returns>Task of ApiResponse (DeviceLogSerializer)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<DeviceLogSerializer>> DeviceLogCreateAsyncWithHttpInfo (DateTime? dateTime, string deviceLogId = null, string eventType = null, bool? stateChange = null, string dateTime2 = null, string deviceId = null, string deviceLogId2 = null, string eventType2 = null, string stateChange2 = null)
        {
            // verify the required parameter 'dateTime' is set
            if (dateTime == null) throw new ApiException(400, "Missing required parameter 'dateTime' when calling DeviceLogCreate");
            
    
            var localVarPath = "/v3/devicelog/";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            
            if (dateTime2 != null) localVarQueryParams.Add("date_time", Configuration.ApiClient.ParameterToString(dateTime2)); // query parameter
            if (deviceId != null) localVarQueryParams.Add("device_id", Configuration.ApiClient.ParameterToString(deviceId)); // query parameter
            if (deviceLogId2 != null) localVarQueryParams.Add("device_log_id", Configuration.ApiClient.ParameterToString(deviceLogId2)); // query parameter
            if (eventType2 != null) localVarQueryParams.Add("event_type", Configuration.ApiClient.ParameterToString(eventType2)); // query parameter
            if (stateChange2 != null) localVarQueryParams.Add("state_change", Configuration.ApiClient.ParameterToString(stateChange2)); // query parameter
            
            
            if (dateTime != null) localVarFormParams.Add("date_time", Configuration.ApiClient.ParameterToString(dateTime)); // form parameter
            if (deviceLogId != null) localVarFormParams.Add("device_log_id", Configuration.ApiClient.ParameterToString(deviceLogId)); // form parameter
            if (eventType != null) localVarFormParams.Add("event_type", Configuration.ApiClient.ParameterToString(eventType)); // form parameter
            if (stateChange != null) localVarFormParams.Add("state_change", Configuration.ApiClient.ParameterToString(stateChange)); // form parameter
            
            

            
            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath, 
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams, 
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DeviceLogCreate: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DeviceLogCreate: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<DeviceLogSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DeviceLogSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DeviceLogSerializer)));
            
        }
        
        /// <summary>
        /// The APIs for creating and manipulating devices &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param> 
        /// <param name="dateTime"> (optional)</param> 
        /// <param name="deviceId"> (optional)</param> 
        /// <param name="deviceLogId2"> (optional)</param> 
        /// <param name="eventType"> (optional)</param> 
        /// <param name="stateChange"> (optional)</param> 
        /// <returns>DeviceLogSerializer</returns>
        public DeviceLogSerializer DeviceLogDestroy (string deviceLogId, string dateTime = null, string deviceId = null, string deviceLogId2 = null, string eventType = null, string stateChange = null)
        {
             ApiResponse<DeviceLogSerializer> localVarResponse = DeviceLogDestroyWithHttpInfo(deviceLogId, dateTime, deviceId, deviceLogId2, eventType, stateChange);
             return localVarResponse.Data;
        }

        /// <summary>
        /// The APIs for creating and manipulating devices &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param> 
        /// <param name="dateTime"> (optional)</param> 
        /// <param name="deviceId"> (optional)</param> 
        /// <param name="deviceLogId2"> (optional)</param> 
        /// <param name="eventType"> (optional)</param> 
        /// <param name="stateChange"> (optional)</param> 
        /// <returns>ApiResponse of DeviceLogSerializer</returns>
        public ApiResponse< DeviceLogSerializer > DeviceLogDestroyWithHttpInfo (string deviceLogId, string dateTime = null, string deviceId = null, string deviceLogId2 = null, string eventType = null, string stateChange = null)
        {
            
            // verify the required parameter 'deviceLogId' is set
            if (deviceLogId == null)
                throw new ApiException(400, "Missing required parameter 'deviceLogId' when calling DefaultApi->DeviceLogDestroy");
            
    
            var localVarPath = "/v3/devicelog/{device_log_id}/";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (deviceLogId != null) localVarPathParams.Add("device_log_id", Configuration.ApiClient.ParameterToString(deviceLogId)); // path parameter
            
            if (dateTime != null) localVarQueryParams.Add("date_time", Configuration.ApiClient.ParameterToString(dateTime)); // query parameter
            if (deviceId != null) localVarQueryParams.Add("device_id", Configuration.ApiClient.ParameterToString(deviceId)); // query parameter
            if (deviceLogId2 != null) localVarQueryParams.Add("device_log_id", Configuration.ApiClient.ParameterToString(deviceLogId2)); // query parameter
            if (eventType != null) localVarQueryParams.Add("event_type", Configuration.ApiClient.ParameterToString(eventType)); // query parameter
            if (stateChange != null) localVarQueryParams.Add("state_change", Configuration.ApiClient.ParameterToString(stateChange)); // query parameter
            
            
            
            

            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            
    
            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath, 
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DeviceLogDestroy: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DeviceLogDestroy: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<DeviceLogSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DeviceLogSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DeviceLogSerializer)));
            
        }

        
        /// <summary>
        /// The APIs for creating and manipulating devices &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param>
        /// <param name="dateTime"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId2"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <returns>Task of DeviceLogSerializer</returns>
        public async System.Threading.Tasks.Task<DeviceLogSerializer> DeviceLogDestroyAsync (string deviceLogId, string dateTime = null, string deviceId = null, string deviceLogId2 = null, string eventType = null, string stateChange = null)
        {
             ApiResponse<DeviceLogSerializer> localVarResponse = await DeviceLogDestroyAsyncWithHttpInfo(deviceLogId, dateTime, deviceId, deviceLogId2, eventType, stateChange);
             return localVarResponse.Data;

        }

        /// <summary>
        /// The APIs for creating and manipulating devices &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param>
        /// <param name="dateTime"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId2"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <returns>Task of ApiResponse (DeviceLogSerializer)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<DeviceLogSerializer>> DeviceLogDestroyAsyncWithHttpInfo (string deviceLogId, string dateTime = null, string deviceId = null, string deviceLogId2 = null, string eventType = null, string stateChange = null)
        {
            // verify the required parameter 'deviceLogId' is set
            if (deviceLogId == null) throw new ApiException(400, "Missing required parameter 'deviceLogId' when calling DeviceLogDestroy");
            
    
            var localVarPath = "/v3/devicelog/{device_log_id}/";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (deviceLogId != null) localVarPathParams.Add("device_log_id", Configuration.ApiClient.ParameterToString(deviceLogId)); // path parameter
            
            if (dateTime != null) localVarQueryParams.Add("date_time", Configuration.ApiClient.ParameterToString(dateTime)); // query parameter
            if (deviceId != null) localVarQueryParams.Add("device_id", Configuration.ApiClient.ParameterToString(deviceId)); // query parameter
            if (deviceLogId2 != null) localVarQueryParams.Add("device_log_id", Configuration.ApiClient.ParameterToString(deviceLogId2)); // query parameter
            if (eventType != null) localVarQueryParams.Add("event_type", Configuration.ApiClient.ParameterToString(eventType)); // query parameter
            if (stateChange != null) localVarQueryParams.Add("state_change", Configuration.ApiClient.ParameterToString(stateChange)); // query parameter
            
            
            
            

            
            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath, 
                Method.DELETE, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams, 
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DeviceLogDestroy: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DeviceLogDestroy: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<DeviceLogSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DeviceLogSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DeviceLogSerializer)));
            
        }
        
        /// <summary>
        /// List all device logs &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;List all device logs.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dateTime"> (optional)</param> 
        /// <param name="deviceId"> (optional)</param> 
        /// <param name="deviceLogId"> (optional)</param> 
        /// <param name="eventType"> (optional)</param> 
        /// <param name="stateChange"> (optional)</param> 
        /// <returns>List&lt;DeviceLogSerializer&gt;</returns>
        public List<DeviceLogSerializer> DeviceLogList (string dateTime = null, string deviceId = null, string deviceLogId = null, string eventType = null, string stateChange = null)
        {
             ApiResponse<List<DeviceLogSerializer>> localVarResponse = DeviceLogListWithHttpInfo(dateTime, deviceId, deviceLogId, eventType, stateChange);
             return localVarResponse.Data;
        }

        /// <summary>
        /// List all device logs &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;List all device logs.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dateTime"> (optional)</param> 
        /// <param name="deviceId"> (optional)</param> 
        /// <param name="deviceLogId"> (optional)</param> 
        /// <param name="eventType"> (optional)</param> 
        /// <param name="stateChange"> (optional)</param> 
        /// <returns>ApiResponse of List&lt;DeviceLogSerializer&gt;</returns>
        public ApiResponse< List<DeviceLogSerializer> > DeviceLogListWithHttpInfo (string dateTime = null, string deviceId = null, string deviceLogId = null, string eventType = null, string stateChange = null)
        {
            
    
            var localVarPath = "/v3/devicelog/";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            
            if (dateTime != null) localVarQueryParams.Add("date_time", Configuration.ApiClient.ParameterToString(dateTime)); // query parameter
            if (deviceId != null) localVarQueryParams.Add("device_id", Configuration.ApiClient.ParameterToString(deviceId)); // query parameter
            if (deviceLogId != null) localVarQueryParams.Add("device_log_id", Configuration.ApiClient.ParameterToString(deviceLogId)); // query parameter
            if (eventType != null) localVarQueryParams.Add("event_type", Configuration.ApiClient.ParameterToString(eventType)); // query parameter
            if (stateChange != null) localVarQueryParams.Add("state_change", Configuration.ApiClient.ParameterToString(stateChange)); // query parameter
            
            
            
            

            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            
    
            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath, 
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DeviceLogList: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DeviceLogList: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<List<DeviceLogSerializer>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<DeviceLogSerializer>) Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<DeviceLogSerializer>)));
            
        }

        
        /// <summary>
        /// List all device logs &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;List all device logs.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dateTime"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <returns>Task of List&lt;DeviceLogSerializer&gt;</returns>
        public async System.Threading.Tasks.Task<List<DeviceLogSerializer>> DeviceLogListAsync (string dateTime = null, string deviceId = null, string deviceLogId = null, string eventType = null, string stateChange = null)
        {
             ApiResponse<List<DeviceLogSerializer>> localVarResponse = await DeviceLogListAsyncWithHttpInfo(dateTime, deviceId, deviceLogId, eventType, stateChange);
             return localVarResponse.Data;

        }

        /// <summary>
        /// List all device logs &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;List all device logs.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="dateTime"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;DeviceLogSerializer&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<DeviceLogSerializer>>> DeviceLogListAsyncWithHttpInfo (string dateTime = null, string deviceId = null, string deviceLogId = null, string eventType = null, string stateChange = null)
        {
            
    
            var localVarPath = "/v3/devicelog/";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            
            if (dateTime != null) localVarQueryParams.Add("date_time", Configuration.ApiClient.ParameterToString(dateTime)); // query parameter
            if (deviceId != null) localVarQueryParams.Add("device_id", Configuration.ApiClient.ParameterToString(deviceId)); // query parameter
            if (deviceLogId != null) localVarQueryParams.Add("device_log_id", Configuration.ApiClient.ParameterToString(deviceLogId)); // query parameter
            if (eventType != null) localVarQueryParams.Add("event_type", Configuration.ApiClient.ParameterToString(eventType)); // query parameter
            if (stateChange != null) localVarQueryParams.Add("state_change", Configuration.ApiClient.ParameterToString(stateChange)); // query parameter
            
            
            
            

            
            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath, 
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams, 
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DeviceLogList: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DeviceLogList: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<List<DeviceLogSerializer>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<DeviceLogSerializer>) Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<DeviceLogSerializer>)));
            
        }
        
        /// <summary>
        /// The APIs for creating and manipulating devices &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param> 
        /// <param name="dateTime"> (optional)</param> 
        /// <param name="deviceLogId2"> (optional)</param> 
        /// <param name="eventType"> (optional)</param> 
        /// <param name="stateChange"> (optional)</param> 
        /// <param name="dateTime2"> (optional)</param> 
        /// <param name="deviceId"> (optional)</param> 
        /// <param name="deviceLogId3"> (optional)</param> 
        /// <param name="eventType2"> (optional)</param> 
        /// <param name="stateChange2"> (optional)</param> 
        /// <returns>DeviceLogSerializer</returns>
        public DeviceLogSerializer DeviceLogPartialUpdate (string deviceLogId, DateTime? dateTime = null, string deviceLogId2 = null, string eventType = null, bool? stateChange = null, string dateTime2 = null, string deviceId = null, string deviceLogId3 = null, string eventType2 = null, string stateChange2 = null)
        {
             ApiResponse<DeviceLogSerializer> localVarResponse = DeviceLogPartialUpdateWithHttpInfo(deviceLogId, dateTime, deviceLogId2, eventType, stateChange, dateTime2, deviceId, deviceLogId3, eventType2, stateChange2);
             return localVarResponse.Data;
        }

        /// <summary>
        /// The APIs for creating and manipulating devices &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param> 
        /// <param name="dateTime"> (optional)</param> 
        /// <param name="deviceLogId2"> (optional)</param> 
        /// <param name="eventType"> (optional)</param> 
        /// <param name="stateChange"> (optional)</param> 
        /// <param name="dateTime2"> (optional)</param> 
        /// <param name="deviceId"> (optional)</param> 
        /// <param name="deviceLogId3"> (optional)</param> 
        /// <param name="eventType2"> (optional)</param> 
        /// <param name="stateChange2"> (optional)</param> 
        /// <returns>ApiResponse of DeviceLogSerializer</returns>
        public ApiResponse< DeviceLogSerializer > DeviceLogPartialUpdateWithHttpInfo (string deviceLogId, DateTime? dateTime = null, string deviceLogId2 = null, string eventType = null, bool? stateChange = null, string dateTime2 = null, string deviceId = null, string deviceLogId3 = null, string eventType2 = null, string stateChange2 = null)
        {
            
            // verify the required parameter 'deviceLogId' is set
            if (deviceLogId == null)
                throw new ApiException(400, "Missing required parameter 'deviceLogId' when calling DefaultApi->DeviceLogPartialUpdate");
            
    
            var localVarPath = "/v3/devicelog/{device_log_id}/";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (deviceLogId != null) localVarPathParams.Add("device_log_id", Configuration.ApiClient.ParameterToString(deviceLogId)); // path parameter
            
            if (dateTime2 != null) localVarQueryParams.Add("date_time", Configuration.ApiClient.ParameterToString(dateTime2)); // query parameter
            if (deviceId != null) localVarQueryParams.Add("device_id", Configuration.ApiClient.ParameterToString(deviceId)); // query parameter
            if (deviceLogId3 != null) localVarQueryParams.Add("device_log_id", Configuration.ApiClient.ParameterToString(deviceLogId3)); // query parameter
            if (eventType2 != null) localVarQueryParams.Add("event_type", Configuration.ApiClient.ParameterToString(eventType2)); // query parameter
            if (stateChange2 != null) localVarQueryParams.Add("state_change", Configuration.ApiClient.ParameterToString(stateChange2)); // query parameter
            
            
            if (dateTime != null) localVarFormParams.Add("date_time", Configuration.ApiClient.ParameterToString(dateTime)); // form parameter
            if (deviceLogId2 != null) localVarFormParams.Add("device_log_id", Configuration.ApiClient.ParameterToString(deviceLogId2)); // form parameter
            if (eventType != null) localVarFormParams.Add("event_type", Configuration.ApiClient.ParameterToString(eventType)); // form parameter
            if (stateChange != null) localVarFormParams.Add("state_change", Configuration.ApiClient.ParameterToString(stateChange)); // form parameter
            
            

            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            
    
            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath, 
                Method.PATCH, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DeviceLogPartialUpdate: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DeviceLogPartialUpdate: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<DeviceLogSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DeviceLogSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DeviceLogSerializer)));
            
        }

        
        /// <summary>
        /// The APIs for creating and manipulating devices &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param>
        /// <param name="dateTime"> (optional)</param>
        /// <param name="deviceLogId2"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <param name="dateTime2"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId3"> (optional)</param>
        /// <param name="eventType2"> (optional)</param>
        /// <param name="stateChange2"> (optional)</param>
        /// <returns>Task of DeviceLogSerializer</returns>
        public async System.Threading.Tasks.Task<DeviceLogSerializer> DeviceLogPartialUpdateAsync (string deviceLogId, DateTime? dateTime = null, string deviceLogId2 = null, string eventType = null, bool? stateChange = null, string dateTime2 = null, string deviceId = null, string deviceLogId3 = null, string eventType2 = null, string stateChange2 = null)
        {
             ApiResponse<DeviceLogSerializer> localVarResponse = await DeviceLogPartialUpdateAsyncWithHttpInfo(deviceLogId, dateTime, deviceLogId2, eventType, stateChange, dateTime2, deviceId, deviceLogId3, eventType2, stateChange2);
             return localVarResponse.Data;

        }

        /// <summary>
        /// The APIs for creating and manipulating devices &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param>
        /// <param name="dateTime"> (optional)</param>
        /// <param name="deviceLogId2"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <param name="dateTime2"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId3"> (optional)</param>
        /// <param name="eventType2"> (optional)</param>
        /// <param name="stateChange2"> (optional)</param>
        /// <returns>Task of ApiResponse (DeviceLogSerializer)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<DeviceLogSerializer>> DeviceLogPartialUpdateAsyncWithHttpInfo (string deviceLogId, DateTime? dateTime = null, string deviceLogId2 = null, string eventType = null, bool? stateChange = null, string dateTime2 = null, string deviceId = null, string deviceLogId3 = null, string eventType2 = null, string stateChange2 = null)
        {
            // verify the required parameter 'deviceLogId' is set
            if (deviceLogId == null) throw new ApiException(400, "Missing required parameter 'deviceLogId' when calling DeviceLogPartialUpdate");
            
    
            var localVarPath = "/v3/devicelog/{device_log_id}/";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (deviceLogId != null) localVarPathParams.Add("device_log_id", Configuration.ApiClient.ParameterToString(deviceLogId)); // path parameter
            
            if (dateTime2 != null) localVarQueryParams.Add("date_time", Configuration.ApiClient.ParameterToString(dateTime2)); // query parameter
            if (deviceId != null) localVarQueryParams.Add("device_id", Configuration.ApiClient.ParameterToString(deviceId)); // query parameter
            if (deviceLogId3 != null) localVarQueryParams.Add("device_log_id", Configuration.ApiClient.ParameterToString(deviceLogId3)); // query parameter
            if (eventType2 != null) localVarQueryParams.Add("event_type", Configuration.ApiClient.ParameterToString(eventType2)); // query parameter
            if (stateChange2 != null) localVarQueryParams.Add("state_change", Configuration.ApiClient.ParameterToString(stateChange2)); // query parameter
            
            
            if (dateTime != null) localVarFormParams.Add("date_time", Configuration.ApiClient.ParameterToString(dateTime)); // form parameter
            if (deviceLogId2 != null) localVarFormParams.Add("device_log_id", Configuration.ApiClient.ParameterToString(deviceLogId2)); // form parameter
            if (eventType != null) localVarFormParams.Add("event_type", Configuration.ApiClient.ParameterToString(eventType)); // form parameter
            if (stateChange != null) localVarFormParams.Add("state_change", Configuration.ApiClient.ParameterToString(stateChange)); // form parameter
            
            

            
            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath, 
                Method.PATCH, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams, 
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DeviceLogPartialUpdate: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DeviceLogPartialUpdate: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<DeviceLogSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DeviceLogSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DeviceLogSerializer)));
            
        }
        
        /// <summary>
        /// Retrieve device log &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Retrieve device log.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param> 
        /// <returns>DeviceLogSerializer</returns>
        public DeviceLogSerializer DeviceLogRetrieve (string deviceLogId)
        {
             ApiResponse<DeviceLogSerializer> localVarResponse = DeviceLogRetrieveWithHttpInfo(deviceLogId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve device log &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Retrieve device log.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param> 
        /// <returns>ApiResponse of DeviceLogSerializer</returns>
        public ApiResponse< DeviceLogSerializer > DeviceLogRetrieveWithHttpInfo (string deviceLogId)
        {
            
            // verify the required parameter 'deviceLogId' is set
            if (deviceLogId == null)
                throw new ApiException(400, "Missing required parameter 'deviceLogId' when calling DefaultApi->DeviceLogRetrieve");
            
    
            var localVarPath = "/v3/devicelog/{device_log_id}/";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (deviceLogId != null) localVarPathParams.Add("device_log_id", Configuration.ApiClient.ParameterToString(deviceLogId)); // path parameter
            
            
            
            
            

            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            
    
            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath, 
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DeviceLogRetrieve: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DeviceLogRetrieve: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<DeviceLogSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DeviceLogSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DeviceLogSerializer)));
            
        }

        
        /// <summary>
        /// Retrieve device log &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Retrieve device log.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param>
        /// <returns>Task of DeviceLogSerializer</returns>
        public async System.Threading.Tasks.Task<DeviceLogSerializer> DeviceLogRetrieveAsync (string deviceLogId)
        {
             ApiResponse<DeviceLogSerializer> localVarResponse = await DeviceLogRetrieveAsyncWithHttpInfo(deviceLogId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Retrieve device log &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Retrieve device log.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param>
        /// <returns>Task of ApiResponse (DeviceLogSerializer)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<DeviceLogSerializer>> DeviceLogRetrieveAsyncWithHttpInfo (string deviceLogId)
        {
            // verify the required parameter 'deviceLogId' is set
            if (deviceLogId == null) throw new ApiException(400, "Missing required parameter 'deviceLogId' when calling DeviceLogRetrieve");
            
    
            var localVarPath = "/v3/devicelog/{device_log_id}/";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (deviceLogId != null) localVarPathParams.Add("device_log_id", Configuration.ApiClient.ParameterToString(deviceLogId)); // path parameter
            
            
            
            
            

            
            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath, 
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams, 
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DeviceLogRetrieve: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DeviceLogRetrieve: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<DeviceLogSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DeviceLogSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DeviceLogSerializer)));
            
        }
        
        /// <summary>
        /// The APIs for creating and manipulating devices &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param> 
        /// <param name="dateTime"></param> 
        /// <param name="deviceLogId2"> (optional)</param> 
        /// <param name="eventType"> (optional)</param> 
        /// <param name="stateChange"> (optional)</param> 
        /// <param name="dateTime2"> (optional)</param> 
        /// <param name="deviceId"> (optional)</param> 
        /// <param name="deviceLogId3"> (optional)</param> 
        /// <param name="eventType2"> (optional)</param> 
        /// <param name="stateChange2"> (optional)</param> 
        /// <returns>DeviceLogSerializer</returns>
        public DeviceLogSerializer DeviceLogUpdate (string deviceLogId, DateTime? dateTime, string deviceLogId2 = null, string eventType = null, bool? stateChange = null, string dateTime2 = null, string deviceId = null, string deviceLogId3 = null, string eventType2 = null, string stateChange2 = null)
        {
             ApiResponse<DeviceLogSerializer> localVarResponse = DeviceLogUpdateWithHttpInfo(deviceLogId, dateTime, deviceLogId2, eventType, stateChange, dateTime2, deviceId, deviceLogId3, eventType2, stateChange2);
             return localVarResponse.Data;
        }

        /// <summary>
        /// The APIs for creating and manipulating devices &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param> 
        /// <param name="dateTime"></param> 
        /// <param name="deviceLogId2"> (optional)</param> 
        /// <param name="eventType"> (optional)</param> 
        /// <param name="stateChange"> (optional)</param> 
        /// <param name="dateTime2"> (optional)</param> 
        /// <param name="deviceId"> (optional)</param> 
        /// <param name="deviceLogId3"> (optional)</param> 
        /// <param name="eventType2"> (optional)</param> 
        /// <param name="stateChange2"> (optional)</param> 
        /// <returns>ApiResponse of DeviceLogSerializer</returns>
        public ApiResponse< DeviceLogSerializer > DeviceLogUpdateWithHttpInfo (string deviceLogId, DateTime? dateTime, string deviceLogId2 = null, string eventType = null, bool? stateChange = null, string dateTime2 = null, string deviceId = null, string deviceLogId3 = null, string eventType2 = null, string stateChange2 = null)
        {
            
            // verify the required parameter 'deviceLogId' is set
            if (deviceLogId == null)
                throw new ApiException(400, "Missing required parameter 'deviceLogId' when calling DefaultApi->DeviceLogUpdate");
            
            // verify the required parameter 'dateTime' is set
            if (dateTime == null)
                throw new ApiException(400, "Missing required parameter 'dateTime' when calling DefaultApi->DeviceLogUpdate");
            
    
            var localVarPath = "/v3/devicelog/{device_log_id}/";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (deviceLogId != null) localVarPathParams.Add("device_log_id", Configuration.ApiClient.ParameterToString(deviceLogId)); // path parameter
            
            if (dateTime2 != null) localVarQueryParams.Add("date_time", Configuration.ApiClient.ParameterToString(dateTime2)); // query parameter
            if (deviceId != null) localVarQueryParams.Add("device_id", Configuration.ApiClient.ParameterToString(deviceId)); // query parameter
            if (deviceLogId3 != null) localVarQueryParams.Add("device_log_id", Configuration.ApiClient.ParameterToString(deviceLogId3)); // query parameter
            if (eventType2 != null) localVarQueryParams.Add("event_type", Configuration.ApiClient.ParameterToString(eventType2)); // query parameter
            if (stateChange2 != null) localVarQueryParams.Add("state_change", Configuration.ApiClient.ParameterToString(stateChange2)); // query parameter
            
            
            if (dateTime != null) localVarFormParams.Add("date_time", Configuration.ApiClient.ParameterToString(dateTime)); // form parameter
            if (deviceLogId2 != null) localVarFormParams.Add("device_log_id", Configuration.ApiClient.ParameterToString(deviceLogId2)); // form parameter
            if (eventType != null) localVarFormParams.Add("event_type", Configuration.ApiClient.ParameterToString(eventType)); // form parameter
            if (stateChange != null) localVarFormParams.Add("state_change", Configuration.ApiClient.ParameterToString(stateChange)); // form parameter
            
            

            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            
    
            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath, 
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DeviceLogUpdate: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DeviceLogUpdate: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<DeviceLogSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DeviceLogSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DeviceLogSerializer)));
            
        }

        
        /// <summary>
        /// The APIs for creating and manipulating devices &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param>
        /// <param name="dateTime"></param>
        /// <param name="deviceLogId2"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <param name="dateTime2"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId3"> (optional)</param>
        /// <param name="eventType2"> (optional)</param>
        /// <param name="stateChange2"> (optional)</param>
        /// <returns>Task of DeviceLogSerializer</returns>
        public async System.Threading.Tasks.Task<DeviceLogSerializer> DeviceLogUpdateAsync (string deviceLogId, DateTime? dateTime, string deviceLogId2 = null, string eventType = null, bool? stateChange = null, string dateTime2 = null, string deviceId = null, string deviceLogId3 = null, string eventType2 = null, string stateChange2 = null)
        {
             ApiResponse<DeviceLogSerializer> localVarResponse = await DeviceLogUpdateAsyncWithHttpInfo(deviceLogId, dateTime, deviceLogId2, eventType, stateChange, dateTime2, deviceId, deviceLogId3, eventType2, stateChange2);
             return localVarResponse.Data;

        }

        /// <summary>
        /// The APIs for creating and manipulating devices &lt;p&gt;The APIs for creating and manipulating devices.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceLogId"></param>
        /// <param name="dateTime"></param>
        /// <param name="deviceLogId2"> (optional)</param>
        /// <param name="eventType"> (optional)</param>
        /// <param name="stateChange"> (optional)</param>
        /// <param name="dateTime2"> (optional)</param>
        /// <param name="deviceId"> (optional)</param>
        /// <param name="deviceLogId3"> (optional)</param>
        /// <param name="eventType2"> (optional)</param>
        /// <param name="stateChange2"> (optional)</param>
        /// <returns>Task of ApiResponse (DeviceLogSerializer)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<DeviceLogSerializer>> DeviceLogUpdateAsyncWithHttpInfo (string deviceLogId, DateTime? dateTime, string deviceLogId2 = null, string eventType = null, bool? stateChange = null, string dateTime2 = null, string deviceId = null, string deviceLogId3 = null, string eventType2 = null, string stateChange2 = null)
        {
            // verify the required parameter 'deviceLogId' is set
            if (deviceLogId == null) throw new ApiException(400, "Missing required parameter 'deviceLogId' when calling DeviceLogUpdate");
            // verify the required parameter 'dateTime' is set
            if (dateTime == null) throw new ApiException(400, "Missing required parameter 'dateTime' when calling DeviceLogUpdate");
            
    
            var localVarPath = "/v3/devicelog/{device_log_id}/";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (deviceLogId != null) localVarPathParams.Add("device_log_id", Configuration.ApiClient.ParameterToString(deviceLogId)); // path parameter
            
            if (dateTime2 != null) localVarQueryParams.Add("date_time", Configuration.ApiClient.ParameterToString(dateTime2)); // query parameter
            if (deviceId != null) localVarQueryParams.Add("device_id", Configuration.ApiClient.ParameterToString(deviceId)); // query parameter
            if (deviceLogId3 != null) localVarQueryParams.Add("device_log_id", Configuration.ApiClient.ParameterToString(deviceLogId3)); // query parameter
            if (eventType2 != null) localVarQueryParams.Add("event_type", Configuration.ApiClient.ParameterToString(eventType2)); // query parameter
            if (stateChange2 != null) localVarQueryParams.Add("state_change", Configuration.ApiClient.ParameterToString(stateChange2)); // query parameter
            
            
            if (dateTime != null) localVarFormParams.Add("date_time", Configuration.ApiClient.ParameterToString(dateTime)); // form parameter
            if (deviceLogId2 != null) localVarFormParams.Add("device_log_id", Configuration.ApiClient.ParameterToString(deviceLogId2)); // form parameter
            if (eventType != null) localVarFormParams.Add("event_type", Configuration.ApiClient.ParameterToString(eventType)); // form parameter
            if (stateChange != null) localVarFormParams.Add("state_change", Configuration.ApiClient.ParameterToString(stateChange)); // form parameter
            
            

            
            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath, 
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams, 
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DeviceLogUpdate: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DeviceLogUpdate: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<DeviceLogSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DeviceLogSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DeviceLogSerializer)));
            
        }
        
        /// <summary>
        /// Update device fields &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Update device fields&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId">The ID of the device</param> 
        /// <returns>DeviceSerializer</returns>
        public DeviceSerializer DevicePartialUpdate (string deviceId)
        {
             ApiResponse<DeviceSerializer> localVarResponse = DevicePartialUpdateWithHttpInfo(deviceId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Update device fields &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Update device fields&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId">The ID of the device</param> 
        /// <returns>ApiResponse of DeviceSerializer</returns>
        public ApiResponse< DeviceSerializer > DevicePartialUpdateWithHttpInfo (string deviceId)
        {
            
            // verify the required parameter 'deviceId' is set
            if (deviceId == null)
                throw new ApiException(400, "Missing required parameter 'deviceId' when calling DefaultApi->DevicePartialUpdate");
            
    
            var localVarPath = "/v3/devices/{device_id}/";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (deviceId != null) localVarPathParams.Add("device_id", Configuration.ApiClient.ParameterToString(deviceId)); // path parameter
            
            
            
            
            

            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            
    
            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath, 
                Method.PATCH, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DevicePartialUpdate: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DevicePartialUpdate: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<DeviceSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DeviceSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DeviceSerializer)));
            
        }

        
        /// <summary>
        /// Update device fields &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Update device fields&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId">The ID of the device</param>
        /// <returns>Task of DeviceSerializer</returns>
        public async System.Threading.Tasks.Task<DeviceSerializer> DevicePartialUpdateAsync (string deviceId)
        {
             ApiResponse<DeviceSerializer> localVarResponse = await DevicePartialUpdateAsyncWithHttpInfo(deviceId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Update device fields &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Update device fields&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId">The ID of the device</param>
        /// <returns>Task of ApiResponse (DeviceSerializer)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<DeviceSerializer>> DevicePartialUpdateAsyncWithHttpInfo (string deviceId)
        {
            // verify the required parameter 'deviceId' is set
            if (deviceId == null) throw new ApiException(400, "Missing required parameter 'deviceId' when calling DevicePartialUpdate");
            
    
            var localVarPath = "/v3/devices/{device_id}/";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (deviceId != null) localVarPathParams.Add("device_id", Configuration.ApiClient.ParameterToString(deviceId)); // path parameter
            
            
            
            
            

            
            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath, 
                Method.PATCH, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams, 
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DevicePartialUpdate: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DevicePartialUpdate: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<DeviceSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DeviceSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DeviceSerializer)));
            
        }
        
        /// <summary>
        /// Retrieve device &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Retrieve device.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId"></param> 
        /// <returns>DeviceSerializer</returns>
        public DeviceSerializer DeviceRetrieve (string deviceId)
        {
             ApiResponse<DeviceSerializer> localVarResponse = DeviceRetrieveWithHttpInfo(deviceId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve device &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Retrieve device.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId"></param> 
        /// <returns>ApiResponse of DeviceSerializer</returns>
        public ApiResponse< DeviceSerializer > DeviceRetrieveWithHttpInfo (string deviceId)
        {
            
            // verify the required parameter 'deviceId' is set
            if (deviceId == null)
                throw new ApiException(400, "Missing required parameter 'deviceId' when calling DefaultApi->DeviceRetrieve");
            
    
            var localVarPath = "/v3/devices/{device_id}/";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (deviceId != null) localVarPathParams.Add("device_id", Configuration.ApiClient.ParameterToString(deviceId)); // path parameter
            
            
            
            
            

            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            
    
            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath, 
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DeviceRetrieve: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DeviceRetrieve: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<DeviceSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DeviceSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DeviceSerializer)));
            
        }

        
        /// <summary>
        /// Retrieve device &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Retrieve device.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId"></param>
        /// <returns>Task of DeviceSerializer</returns>
        public async System.Threading.Tasks.Task<DeviceSerializer> DeviceRetrieveAsync (string deviceId)
        {
             ApiResponse<DeviceSerializer> localVarResponse = await DeviceRetrieveAsyncWithHttpInfo(deviceId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Retrieve device &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Retrieve device.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId"></param>
        /// <returns>Task of ApiResponse (DeviceSerializer)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<DeviceSerializer>> DeviceRetrieveAsyncWithHttpInfo (string deviceId)
        {
            // verify the required parameter 'deviceId' is set
            if (deviceId == null) throw new ApiException(400, "Missing required parameter 'deviceId' when calling DeviceRetrieve");
            
    
            var localVarPath = "/v3/devices/{device_id}/";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (deviceId != null) localVarPathParams.Add("device_id", Configuration.ApiClient.ParameterToString(deviceId)); // path parameter
            
            
            
            
            

            
            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath, 
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams, 
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DeviceRetrieve: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DeviceRetrieve: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<DeviceSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DeviceSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DeviceSerializer)));
            
        }
        
        /// <summary>
        /// Update device &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Update device.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId">The ID of the device</param> 
        /// <returns>DeviceSerializer</returns>
        public DeviceSerializer DeviceUpdate (string deviceId)
        {
             ApiResponse<DeviceSerializer> localVarResponse = DeviceUpdateWithHttpInfo(deviceId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Update device &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Update device.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId">The ID of the device</param> 
        /// <returns>ApiResponse of DeviceSerializer</returns>
        public ApiResponse< DeviceSerializer > DeviceUpdateWithHttpInfo (string deviceId)
        {
            
            // verify the required parameter 'deviceId' is set
            if (deviceId == null)
                throw new ApiException(400, "Missing required parameter 'deviceId' when calling DefaultApi->DeviceUpdate");
            
    
            var localVarPath = "/v3/devices/{device_id}/";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (deviceId != null) localVarPathParams.Add("device_id", Configuration.ApiClient.ParameterToString(deviceId)); // path parameter
            
            
            
            
            

            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            
    
            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath, 
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DeviceUpdate: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DeviceUpdate: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<DeviceSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DeviceSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DeviceSerializer)));
            
        }

        
        /// <summary>
        /// Update device &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Update device.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId">The ID of the device</param>
        /// <returns>Task of DeviceSerializer</returns>
        public async System.Threading.Tasks.Task<DeviceSerializer> DeviceUpdateAsync (string deviceId)
        {
             ApiResponse<DeviceSerializer> localVarResponse = await DeviceUpdateAsyncWithHttpInfo(deviceId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Update device &lt;p&gt;The APIs for creating and manipulating devices.  &lt;/p&gt;\n&lt;p&gt;Update device.&lt;/p&gt;
        /// </summary>
        /// <exception cref="device_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="deviceId">The ID of the device</param>
        /// <returns>Task of ApiResponse (DeviceSerializer)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<DeviceSerializer>> DeviceUpdateAsyncWithHttpInfo (string deviceId)
        {
            // verify the required parameter 'deviceId' is set
            if (deviceId == null) throw new ApiException(400, "Missing required parameter 'deviceId' when calling DeviceUpdate");
            
    
            var localVarPath = "/v3/devices/{device_id}/";
    
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            localVarPathParams.Add("format", "json");
            if (deviceId != null) localVarPathParams.Add("device_id", Configuration.ApiClient.ParameterToString(deviceId)); // path parameter
            
            
            
            
            

            
            // authentication (Bearer) required
            
            if (!String.IsNullOrEmpty(Configuration.GetApiKeyWithPrefix("Authorization")))
            {
                localVarHeaderParams["Authorization"] = Configuration.GetApiKeyWithPrefix("Authorization");
            }
            

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath, 
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams, 
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DeviceUpdate: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DeviceUpdate: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<DeviceSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DeviceSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(DeviceSerializer)));
            
        }
        
    }
    
}
