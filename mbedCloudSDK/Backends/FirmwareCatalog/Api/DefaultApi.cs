using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using firmware_catalog.Client;
using firmware_catalog.Model;

namespace firmware_catalog.Api
{
    
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDefaultApi
    {
        #region Synchronous Operations
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;Reads the deploy_info.json file and returns the Build and Git ID to the caller.&lt;/p&gt;\n&lt;p&gt;Will return a 500 error if the file is missing, cannot be parsed or the keys are missing.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Object</returns>
        Object DeployInfoGET ();
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;Reads the deploy_info.json file and returns the Build and Git ID to the caller.&lt;/p&gt;\n&lt;p&gt;Will return a 500 error if the file is missing, cannot be parsed or the keys are missing.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Object</returns>
        ApiResponse<Object> DeployInfoGETWithHttpInfo ();
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;Create firmware image&lt;/p&gt;&lt;pre&gt;YAMLError:\n while scanning a simple key\n  in \&quot;&lt;unicode string&gt;\&quot;, line 16, column 9:\n            Cannot validate the data used to ... \n            ^\ncould not find expected &#39;:&#39;\n  in \&quot;&lt;unicode string&gt;\&quot;, line 17, column 5:\n        - code: 401\n        ^&lt;/pre&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="datafile">The binary file of firmware image</param>
        /// <param name="name">The name of the object</param>
        /// <param name="description">The description of the object (optional)</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name2"> (optional)</param>
        /// <param name="description2"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="imageId"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <returns>FirmwareImageSerializer</returns>
        FirmwareImageSerializer FirmwareImageCreate (string datafile, string name, string description = null, string updatingRequestId = null, string updatingIpAddress = null, string name2 = null, string description2 = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string imageId = null, string _object = null);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;Create firmware image&lt;/p&gt;&lt;pre&gt;YAMLError:\n while scanning a simple key\n  in \&quot;&lt;unicode string&gt;\&quot;, line 16, column 9:\n            Cannot validate the data used to ... \n            ^\ncould not find expected &#39;:&#39;\n  in \&quot;&lt;unicode string&gt;\&quot;, line 17, column 5:\n        - code: 401\n        ^&lt;/pre&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="datafile">The binary file of firmware image</param>
        /// <param name="name">The name of the object</param>
        /// <param name="description">The description of the object (optional)</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name2"> (optional)</param>
        /// <param name="description2"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="imageId"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <returns>ApiResponse of FirmwareImageSerializer</returns>
        ApiResponse<FirmwareImageSerializer> FirmwareImageCreateWithHttpInfo (string datafile, string name, string description = null, string updatingRequestId = null, string updatingIpAddress = null, string name2 = null, string description2 = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string imageId = null, string _object = null);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;Delete firmware image&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="imageId">The ID of the firmware image</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <returns>FirmwareImageSerializer</returns>
        FirmwareImageSerializer FirmwareImageDestroy (int? imageId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string _object = null);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;Delete firmware image&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="imageId">The ID of the firmware image</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <returns>ApiResponse of FirmwareImageSerializer</returns>
        ApiResponse<FirmwareImageSerializer> FirmwareImageDestroyWithHttpInfo (int? imageId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string _object = null);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;List all firmware images. The result will be paged into pages of 100.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="imageId"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="page">The page number to retrieve. If not given, then defaults to first page.\n (optional)</param>
        /// <returns>List&lt;FirmwareImageSerializer&gt;</returns>
        List<FirmwareImageSerializer> FirmwareImageList (string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string imageId = null, string _object = null, int? page = null);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;List all firmware images. The result will be paged into pages of 100.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="imageId"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="page">The page number to retrieve. If not given, then defaults to first page.\n (optional)</param>
        /// <returns>ApiResponse of List&lt;FirmwareImageSerializer&gt;</returns>
        ApiResponse<List<FirmwareImageSerializer>> FirmwareImageListWithHttpInfo (string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string imageId = null, string _object = null, int? page = null);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;Retrieve firmware image&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="imageId">The ID of the firmware image</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <returns>FirmwareImageSerializer</returns>
        FirmwareImageSerializer FirmwareImageRetrieve (int? imageId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string _object = null);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;Retrieve firmware image&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="imageId">The ID of the firmware image</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <returns>ApiResponse of FirmwareImageSerializer</returns>
        ApiResponse<FirmwareImageSerializer> FirmwareImageRetrieveWithHttpInfo (int? imageId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string _object = null);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;Create firmware manifest&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="datafile">The manifest file to create</param>
        /// <param name="name">The name of the object</param>
        /// <param name="description">The description of the object (optional)</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name2"> (optional)</param>
        /// <param name="description2"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="manifestId"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="timestamp"> (optional)</param>
        /// <returns>FirmwareManifestSerializer</returns>
        FirmwareManifestSerializer FirmwareManifestCreate (string datafile, string name, string description = null, string updatingRequestId = null, string updatingIpAddress = null, string name2 = null, string description2 = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string manifestId = null, string _object = null, string timestamp = null);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;Create firmware manifest&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="datafile">The manifest file to create</param>
        /// <param name="name">The name of the object</param>
        /// <param name="description">The description of the object (optional)</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name2"> (optional)</param>
        /// <param name="description2"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="manifestId"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="timestamp"> (optional)</param>
        /// <returns>ApiResponse of FirmwareManifestSerializer</returns>
        ApiResponse<FirmwareManifestSerializer> FirmwareManifestCreateWithHttpInfo (string datafile, string name, string description = null, string updatingRequestId = null, string updatingIpAddress = null, string name2 = null, string description2 = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string manifestId = null, string _object = null, string timestamp = null);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;Delete firmware manifest&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="manifestId">The ID of the firmware manifest</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="timestamp"> (optional)</param>
        /// <returns>FirmwareManifestSerializer</returns>
        FirmwareManifestSerializer FirmwareManifestDestroy (int? manifestId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string _object = null, string timestamp = null);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;Delete firmware manifest&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="manifestId">The ID of the firmware manifest</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="timestamp"> (optional)</param>
        /// <returns>ApiResponse of FirmwareManifestSerializer</returns>
        ApiResponse<FirmwareManifestSerializer> FirmwareManifestDestroyWithHttpInfo (int? manifestId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string _object = null, string timestamp = null);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;List all firmware manifests&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="manifestId"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="timestamp"> (optional)</param>
        /// <param name="page">The page number to retrieve. If not given, then defaults to first page.\n (optional)</param>
        /// <returns>List&lt;FirmwareManifestSerializer&gt;</returns>
        List<FirmwareManifestSerializer> FirmwareManifestList (string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string manifestId = null, string _object = null, string timestamp = null, int? page = null);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;List all firmware manifests&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="manifestId"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="timestamp"> (optional)</param>
        /// <param name="page">The page number to retrieve. If not given, then defaults to first page.\n (optional)</param>
        /// <returns>ApiResponse of List&lt;FirmwareManifestSerializer&gt;</returns>
        ApiResponse<List<FirmwareManifestSerializer>> FirmwareManifestListWithHttpInfo (string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string manifestId = null, string _object = null, string timestamp = null, int? page = null);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;Retrieve firmware manifest&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="manifestId">The ID of the firmware manifest</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="timestamp"> (optional)</param>
        /// <returns>FirmwareManifestSerializer</returns>
        FirmwareManifestSerializer FirmwareManifestRetrieve (int? manifestId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string _object = null, string timestamp = null);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;Retrieve firmware manifest&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="manifestId">The ID of the firmware manifest</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="timestamp"> (optional)</param>
        /// <returns>ApiResponse of FirmwareManifestSerializer</returns>
        ApiResponse<FirmwareManifestSerializer> FirmwareManifestRetrieveWithHttpInfo (int? manifestId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string _object = null, string timestamp = null);
        
        #endregion Synchronous Operations
        
        #region Asynchronous Operations
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;Reads the deploy_info.json file and returns the Build and Git ID to the caller.&lt;/p&gt;\n&lt;p&gt;Will return a 500 error if the file is missing, cannot be parsed or the keys are missing.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of Object</returns>
        System.Threading.Tasks.Task<Object> DeployInfoGETAsync ();

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;Reads the deploy_info.json file and returns the Build and Git ID to the caller.&lt;/p&gt;\n&lt;p&gt;Will return a 500 error if the file is missing, cannot be parsed or the keys are missing.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (Object)</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> DeployInfoGETAsyncWithHttpInfo ();
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;Create firmware image&lt;/p&gt;&lt;pre&gt;YAMLError:\n while scanning a simple key\n  in \&quot;&lt;unicode string&gt;\&quot;, line 16, column 9:\n            Cannot validate the data used to ... \n            ^\ncould not find expected &#39;:&#39;\n  in \&quot;&lt;unicode string&gt;\&quot;, line 17, column 5:\n        - code: 401\n        ^&lt;/pre&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="datafile">The binary file of firmware image</param>
        /// <param name="name">The name of the object</param>
        /// <param name="description">The description of the object (optional)</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name2"> (optional)</param>
        /// <param name="description2"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="imageId"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <returns>Task of FirmwareImageSerializer</returns>
        System.Threading.Tasks.Task<FirmwareImageSerializer> FirmwareImageCreateAsync (string datafile, string name, string description = null, string updatingRequestId = null, string updatingIpAddress = null, string name2 = null, string description2 = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string imageId = null, string _object = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;Create firmware image&lt;/p&gt;&lt;pre&gt;YAMLError:\n while scanning a simple key\n  in \&quot;&lt;unicode string&gt;\&quot;, line 16, column 9:\n            Cannot validate the data used to ... \n            ^\ncould not find expected &#39;:&#39;\n  in \&quot;&lt;unicode string&gt;\&quot;, line 17, column 5:\n        - code: 401\n        ^&lt;/pre&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="datafile">The binary file of firmware image</param>
        /// <param name="name">The name of the object</param>
        /// <param name="description">The description of the object (optional)</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name2"> (optional)</param>
        /// <param name="description2"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="imageId"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <returns>Task of ApiResponse (FirmwareImageSerializer)</returns>
        System.Threading.Tasks.Task<ApiResponse<FirmwareImageSerializer>> FirmwareImageCreateAsyncWithHttpInfo (string datafile, string name, string description = null, string updatingRequestId = null, string updatingIpAddress = null, string name2 = null, string description2 = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string imageId = null, string _object = null);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;Delete firmware image&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="imageId">The ID of the firmware image</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <returns>Task of FirmwareImageSerializer</returns>
        System.Threading.Tasks.Task<FirmwareImageSerializer> FirmwareImageDestroyAsync (int? imageId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string _object = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;Delete firmware image&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="imageId">The ID of the firmware image</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <returns>Task of ApiResponse (FirmwareImageSerializer)</returns>
        System.Threading.Tasks.Task<ApiResponse<FirmwareImageSerializer>> FirmwareImageDestroyAsyncWithHttpInfo (int? imageId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string _object = null);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;List all firmware images. The result will be paged into pages of 100.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="imageId"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="page">The page number to retrieve. If not given, then defaults to first page.\n (optional)</param>
        /// <returns>Task of List&lt;FirmwareImageSerializer&gt;</returns>
        System.Threading.Tasks.Task<List<FirmwareImageSerializer>> FirmwareImageListAsync (string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string imageId = null, string _object = null, int? page = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;List all firmware images. The result will be paged into pages of 100.&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="imageId"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="page">The page number to retrieve. If not given, then defaults to first page.\n (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;FirmwareImageSerializer&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<FirmwareImageSerializer>>> FirmwareImageListAsyncWithHttpInfo (string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string imageId = null, string _object = null, int? page = null);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;Retrieve firmware image&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="imageId">The ID of the firmware image</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <returns>Task of FirmwareImageSerializer</returns>
        System.Threading.Tasks.Task<FirmwareImageSerializer> FirmwareImageRetrieveAsync (int? imageId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string _object = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;Retrieve firmware image&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="imageId">The ID of the firmware image</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <returns>Task of ApiResponse (FirmwareImageSerializer)</returns>
        System.Threading.Tasks.Task<ApiResponse<FirmwareImageSerializer>> FirmwareImageRetrieveAsyncWithHttpInfo (int? imageId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string _object = null);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;Create firmware manifest&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="datafile">The manifest file to create</param>
        /// <param name="name">The name of the object</param>
        /// <param name="description">The description of the object (optional)</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name2"> (optional)</param>
        /// <param name="description2"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="manifestId"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="timestamp"> (optional)</param>
        /// <returns>Task of FirmwareManifestSerializer</returns>
        System.Threading.Tasks.Task<FirmwareManifestSerializer> FirmwareManifestCreateAsync (string datafile, string name, string description = null, string updatingRequestId = null, string updatingIpAddress = null, string name2 = null, string description2 = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string manifestId = null, string _object = null, string timestamp = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;Create firmware manifest&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="datafile">The manifest file to create</param>
        /// <param name="name">The name of the object</param>
        /// <param name="description">The description of the object (optional)</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name2"> (optional)</param>
        /// <param name="description2"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="manifestId"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="timestamp"> (optional)</param>
        /// <returns>Task of ApiResponse (FirmwareManifestSerializer)</returns>
        System.Threading.Tasks.Task<ApiResponse<FirmwareManifestSerializer>> FirmwareManifestCreateAsyncWithHttpInfo (string datafile, string name, string description = null, string updatingRequestId = null, string updatingIpAddress = null, string name2 = null, string description2 = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string manifestId = null, string _object = null, string timestamp = null);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;Delete firmware manifest&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="manifestId">The ID of the firmware manifest</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="timestamp"> (optional)</param>
        /// <returns>Task of FirmwareManifestSerializer</returns>
        System.Threading.Tasks.Task<FirmwareManifestSerializer> FirmwareManifestDestroyAsync (int? manifestId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string _object = null, string timestamp = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;Delete firmware manifest&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="manifestId">The ID of the firmware manifest</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="timestamp"> (optional)</param>
        /// <returns>Task of ApiResponse (FirmwareManifestSerializer)</returns>
        System.Threading.Tasks.Task<ApiResponse<FirmwareManifestSerializer>> FirmwareManifestDestroyAsyncWithHttpInfo (int? manifestId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string _object = null, string timestamp = null);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;List all firmware manifests&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="manifestId"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="timestamp"> (optional)</param>
        /// <param name="page">The page number to retrieve. If not given, then defaults to first page.\n (optional)</param>
        /// <returns>Task of List&lt;FirmwareManifestSerializer&gt;</returns>
        System.Threading.Tasks.Task<List<FirmwareManifestSerializer>> FirmwareManifestListAsync (string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string manifestId = null, string _object = null, string timestamp = null, int? page = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;List all firmware manifests&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="manifestId"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="timestamp"> (optional)</param>
        /// <param name="page">The page number to retrieve. If not given, then defaults to first page.\n (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;FirmwareManifestSerializer&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<FirmwareManifestSerializer>>> FirmwareManifestListAsyncWithHttpInfo (string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string manifestId = null, string _object = null, string timestamp = null, int? page = null);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;Retrieve firmware manifest&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="manifestId">The ID of the firmware manifest</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="timestamp"> (optional)</param>
        /// <returns>Task of FirmwareManifestSerializer</returns>
        System.Threading.Tasks.Task<FirmwareManifestSerializer> FirmwareManifestRetrieveAsync (int? manifestId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string _object = null, string timestamp = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;Retrieve firmware manifest&lt;/p&gt;
        /// </remarks>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="manifestId">The ID of the firmware manifest</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="timestamp"> (optional)</param>
        /// <returns>Task of ApiResponse (FirmwareManifestSerializer)</returns>
        System.Threading.Tasks.Task<ApiResponse<FirmwareManifestSerializer>> FirmwareManifestRetrieveAsyncWithHttpInfo (int? manifestId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string _object = null, string timestamp = null);
        
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
        ///  &lt;p&gt;Reads the deploy_info.json file and returns the Build and Git ID to the caller.&lt;/p&gt;\n&lt;p&gt;Will return a 500 error if the file is missing, cannot be parsed or the keys are missing.&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Object</returns>
        public Object DeployInfoGET ()
        {
             ApiResponse<Object> localVarResponse = DeployInfoGETWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        ///  &lt;p&gt;Reads the deploy_info.json file and returns the Build and Git ID to the caller.&lt;/p&gt;\n&lt;p&gt;Will return a 500 error if the file is missing, cannot be parsed or the keys are missing.&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Object</returns>
        public ApiResponse< Object > DeployInfoGETWithHttpInfo ()
        {
            
    
            var localVarPath = "/v3/fc_deploy_info";
    
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
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
    
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DeployInfoGET: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DeployInfoGET: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Object) Configuration.ApiClient.Deserialize(localVarResponse, typeof(Object)));
            
        }

        
        /// <summary>
        ///  &lt;p&gt;Reads the deploy_info.json file and returns the Build and Git ID to the caller.&lt;/p&gt;\n&lt;p&gt;Will return a 500 error if the file is missing, cannot be parsed or the keys are missing.&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of Object</returns>
        public async System.Threading.Tasks.Task<Object> DeployInfoGETAsync ()
        {
             ApiResponse<Object> localVarResponse = await DeployInfoGETAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        ///  &lt;p&gt;Reads the deploy_info.json file and returns the Build and Git ID to the caller.&lt;/p&gt;\n&lt;p&gt;Will return a 500 error if the file is missing, cannot be parsed or the keys are missing.&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (Object)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> DeployInfoGETAsyncWithHttpInfo ()
        {
            
    
            var localVarPath = "/v3/fc_deploy_info";
    
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
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams, 
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;
 
            if (localVarStatusCode >= 400)
                throw new ApiException (localVarStatusCode, "Error calling DeployInfoGET: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling DeployInfoGET: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Object) Configuration.ApiClient.Deserialize(localVarResponse, typeof(Object)));
            
        }
        
        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;Create firmware image&lt;/p&gt;&lt;pre&gt;YAMLError:\n while scanning a simple key\n  in \&quot;&lt;unicode string&gt;\&quot;, line 16, column 9:\n            Cannot validate the data used to ... \n            ^\ncould not find expected &#39;:&#39;\n  in \&quot;&lt;unicode string&gt;\&quot;, line 17, column 5:\n        - code: 401\n        ^&lt;/pre&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="datafile">The binary file of firmware image</param> 
        /// <param name="name">The name of the object</param> 
        /// <param name="description">The description of the object (optional)</param> 
        /// <param name="updatingRequestId"> (optional)</param> 
        /// <param name="updatingIpAddress"> (optional)</param> 
        /// <param name="name2"> (optional)</param> 
        /// <param name="description2"> (optional)</param> 
        /// <param name="createdAt"> (optional)</param> 
        /// <param name="updatedAt"> (optional)</param> 
        /// <param name="datafileChecksum"> (optional)</param> 
        /// <param name="etag"> (optional)</param> 
        /// <param name="imageId"> (optional)</param> 
        /// <param name="_object"> (optional)</param> 
        /// <returns>FirmwareImageSerializer</returns>
        public FirmwareImageSerializer FirmwareImageCreate (string datafile, string name, string description = null, string updatingRequestId = null, string updatingIpAddress = null, string name2 = null, string description2 = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string imageId = null, string _object = null)
        {
             ApiResponse<FirmwareImageSerializer> localVarResponse = FirmwareImageCreateWithHttpInfo(datafile, name, description, updatingRequestId, updatingIpAddress, name2, description2, createdAt, updatedAt, datafileChecksum, etag, imageId, _object);
             return localVarResponse.Data;
        }

        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;Create firmware image&lt;/p&gt;&lt;pre&gt;YAMLError:\n while scanning a simple key\n  in \&quot;&lt;unicode string&gt;\&quot;, line 16, column 9:\n            Cannot validate the data used to ... \n            ^\ncould not find expected &#39;:&#39;\n  in \&quot;&lt;unicode string&gt;\&quot;, line 17, column 5:\n        - code: 401\n        ^&lt;/pre&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="datafile">The binary file of firmware image</param> 
        /// <param name="name">The name of the object</param> 
        /// <param name="description">The description of the object (optional)</param> 
        /// <param name="updatingRequestId"> (optional)</param> 
        /// <param name="updatingIpAddress"> (optional)</param> 
        /// <param name="name2"> (optional)</param> 
        /// <param name="description2"> (optional)</param> 
        /// <param name="createdAt"> (optional)</param> 
        /// <param name="updatedAt"> (optional)</param> 
        /// <param name="datafileChecksum"> (optional)</param> 
        /// <param name="etag"> (optional)</param> 
        /// <param name="imageId"> (optional)</param> 
        /// <param name="_object"> (optional)</param> 
        /// <returns>ApiResponse of FirmwareImageSerializer</returns>
        public ApiResponse< FirmwareImageSerializer > FirmwareImageCreateWithHttpInfo (string datafile, string name, string description = null, string updatingRequestId = null, string updatingIpAddress = null, string name2 = null, string description2 = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string imageId = null, string _object = null)
        {
            
            // verify the required parameter 'datafile' is set
            if (datafile == null)
                throw new ApiException(400, "Missing required parameter 'datafile' when calling DefaultApi->FirmwareImageCreate");
            
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling DefaultApi->FirmwareImageCreate");
            
    
            var localVarPath = "/v3/firmware/images/";
    
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
            
            if (updatingRequestId != null) localVarQueryParams.Add("updating_request_id", Configuration.ApiClient.ParameterToString(updatingRequestId)); // query parameter
            if (updatingIpAddress != null) localVarQueryParams.Add("updating_ip_address", Configuration.ApiClient.ParameterToString(updatingIpAddress)); // query parameter
            if (name2 != null) localVarQueryParams.Add("name", Configuration.ApiClient.ParameterToString(name2)); // query parameter
            if (description2 != null) localVarQueryParams.Add("description", Configuration.ApiClient.ParameterToString(description2)); // query parameter
            if (createdAt != null) localVarQueryParams.Add("created_at", Configuration.ApiClient.ParameterToString(createdAt)); // query parameter
            if (updatedAt != null) localVarQueryParams.Add("updated_at", Configuration.ApiClient.ParameterToString(updatedAt)); // query parameter
            if (datafileChecksum != null) localVarQueryParams.Add("datafile_checksum", Configuration.ApiClient.ParameterToString(datafileChecksum)); // query parameter
            if (etag != null) localVarQueryParams.Add("etag", Configuration.ApiClient.ParameterToString(etag)); // query parameter
            if (imageId != null) localVarQueryParams.Add("image_id", Configuration.ApiClient.ParameterToString(imageId)); // query parameter
            if (_object != null) localVarQueryParams.Add("object", Configuration.ApiClient.ParameterToString(_object)); // query parameter
            
            
            if (datafile != null) localVarFormParams.Add("datafile", Configuration.ApiClient.ParameterToString(datafile)); // form parameter
            if (description != null) localVarFormParams.Add("description", Configuration.ApiClient.ParameterToString(description)); // form parameter
            if (name != null) localVarFormParams.Add("name", Configuration.ApiClient.ParameterToString(name)); // form parameter
            
            

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
                throw new ApiException (localVarStatusCode, "Error calling FirmwareImageCreate: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling FirmwareImageCreate: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<FirmwareImageSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (FirmwareImageSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(FirmwareImageSerializer)));
            
        }

        
        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;Create firmware image&lt;/p&gt;&lt;pre&gt;YAMLError:\n while scanning a simple key\n  in \&quot;&lt;unicode string&gt;\&quot;, line 16, column 9:\n            Cannot validate the data used to ... \n            ^\ncould not find expected &#39;:&#39;\n  in \&quot;&lt;unicode string&gt;\&quot;, line 17, column 5:\n        - code: 401\n        ^&lt;/pre&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="datafile">The binary file of firmware image</param>
        /// <param name="name">The name of the object</param>
        /// <param name="description">The description of the object (optional)</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name2"> (optional)</param>
        /// <param name="description2"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="imageId"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <returns>Task of FirmwareImageSerializer</returns>
        public async System.Threading.Tasks.Task<FirmwareImageSerializer> FirmwareImageCreateAsync (string datafile, string name, string description = null, string updatingRequestId = null, string updatingIpAddress = null, string name2 = null, string description2 = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string imageId = null, string _object = null)
        {
             ApiResponse<FirmwareImageSerializer> localVarResponse = await FirmwareImageCreateAsyncWithHttpInfo(datafile, name, description, updatingRequestId, updatingIpAddress, name2, description2, createdAt, updatedAt, datafileChecksum, etag, imageId, _object);
             return localVarResponse.Data;

        }

        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;Create firmware image&lt;/p&gt;&lt;pre&gt;YAMLError:\n while scanning a simple key\n  in \&quot;&lt;unicode string&gt;\&quot;, line 16, column 9:\n            Cannot validate the data used to ... \n            ^\ncould not find expected &#39;:&#39;\n  in \&quot;&lt;unicode string&gt;\&quot;, line 17, column 5:\n        - code: 401\n        ^&lt;/pre&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="datafile">The binary file of firmware image</param>
        /// <param name="name">The name of the object</param>
        /// <param name="description">The description of the object (optional)</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name2"> (optional)</param>
        /// <param name="description2"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="imageId"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <returns>Task of ApiResponse (FirmwareImageSerializer)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<FirmwareImageSerializer>> FirmwareImageCreateAsyncWithHttpInfo (string datafile, string name, string description = null, string updatingRequestId = null, string updatingIpAddress = null, string name2 = null, string description2 = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string imageId = null, string _object = null)
        {
            // verify the required parameter 'datafile' is set
            if (datafile == null) throw new ApiException(400, "Missing required parameter 'datafile' when calling FirmwareImageCreate");
            // verify the required parameter 'name' is set
            if (name == null) throw new ApiException(400, "Missing required parameter 'name' when calling FirmwareImageCreate");
            
    
            var localVarPath = "/v3/firmware/images/";
    
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
            
            if (updatingRequestId != null) localVarQueryParams.Add("updating_request_id", Configuration.ApiClient.ParameterToString(updatingRequestId)); // query parameter
            if (updatingIpAddress != null) localVarQueryParams.Add("updating_ip_address", Configuration.ApiClient.ParameterToString(updatingIpAddress)); // query parameter
            if (name2 != null) localVarQueryParams.Add("name", Configuration.ApiClient.ParameterToString(name2)); // query parameter
            if (description2 != null) localVarQueryParams.Add("description", Configuration.ApiClient.ParameterToString(description2)); // query parameter
            if (createdAt != null) localVarQueryParams.Add("created_at", Configuration.ApiClient.ParameterToString(createdAt)); // query parameter
            if (updatedAt != null) localVarQueryParams.Add("updated_at", Configuration.ApiClient.ParameterToString(updatedAt)); // query parameter
            if (datafileChecksum != null) localVarQueryParams.Add("datafile_checksum", Configuration.ApiClient.ParameterToString(datafileChecksum)); // query parameter
            if (etag != null) localVarQueryParams.Add("etag", Configuration.ApiClient.ParameterToString(etag)); // query parameter
            if (imageId != null) localVarQueryParams.Add("image_id", Configuration.ApiClient.ParameterToString(imageId)); // query parameter
            if (_object != null) localVarQueryParams.Add("object", Configuration.ApiClient.ParameterToString(_object)); // query parameter
            
            
            if (datafile != null) localVarFormParams.Add("datafile", Configuration.ApiClient.ParameterToString(datafile)); // form parameter
            if (description != null) localVarFormParams.Add("description", Configuration.ApiClient.ParameterToString(description)); // form parameter
            if (name != null) localVarFormParams.Add("name", Configuration.ApiClient.ParameterToString(name)); // form parameter
            
            

            
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
                throw new ApiException (localVarStatusCode, "Error calling FirmwareImageCreate: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling FirmwareImageCreate: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<FirmwareImageSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (FirmwareImageSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(FirmwareImageSerializer)));
            
        }
        
        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;Delete firmware image&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="imageId">The ID of the firmware image</param> 
        /// <param name="updatingRequestId"> (optional)</param> 
        /// <param name="updatingIpAddress"> (optional)</param> 
        /// <param name="name"> (optional)</param> 
        /// <param name="description"> (optional)</param> 
        /// <param name="createdAt"> (optional)</param> 
        /// <param name="updatedAt"> (optional)</param> 
        /// <param name="datafileChecksum"> (optional)</param> 
        /// <param name="etag"> (optional)</param> 
        /// <param name="_object"> (optional)</param> 
        /// <returns>FirmwareImageSerializer</returns>
        public FirmwareImageSerializer FirmwareImageDestroy (int? imageId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string _object = null)
        {
             ApiResponse<FirmwareImageSerializer> localVarResponse = FirmwareImageDestroyWithHttpInfo(imageId, updatingRequestId, updatingIpAddress, name, description, createdAt, updatedAt, datafileChecksum, etag, _object);
             return localVarResponse.Data;
        }

        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;Delete firmware image&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="imageId">The ID of the firmware image</param> 
        /// <param name="updatingRequestId"> (optional)</param> 
        /// <param name="updatingIpAddress"> (optional)</param> 
        /// <param name="name"> (optional)</param> 
        /// <param name="description"> (optional)</param> 
        /// <param name="createdAt"> (optional)</param> 
        /// <param name="updatedAt"> (optional)</param> 
        /// <param name="datafileChecksum"> (optional)</param> 
        /// <param name="etag"> (optional)</param> 
        /// <param name="_object"> (optional)</param> 
        /// <returns>ApiResponse of FirmwareImageSerializer</returns>
        public ApiResponse< FirmwareImageSerializer > FirmwareImageDestroyWithHttpInfo (int? imageId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string _object = null)
        {
            
            // verify the required parameter 'imageId' is set
            if (imageId == null)
                throw new ApiException(400, "Missing required parameter 'imageId' when calling DefaultApi->FirmwareImageDestroy");
            
    
            var localVarPath = "/v3/firmware/images/{image_id}/";
    
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
            if (imageId != null) localVarPathParams.Add("image_id", Configuration.ApiClient.ParameterToString(imageId)); // path parameter
            
            if (updatingRequestId != null) localVarQueryParams.Add("updating_request_id", Configuration.ApiClient.ParameterToString(updatingRequestId)); // query parameter
            if (updatingIpAddress != null) localVarQueryParams.Add("updating_ip_address", Configuration.ApiClient.ParameterToString(updatingIpAddress)); // query parameter
            if (name != null) localVarQueryParams.Add("name", Configuration.ApiClient.ParameterToString(name)); // query parameter
            if (description != null) localVarQueryParams.Add("description", Configuration.ApiClient.ParameterToString(description)); // query parameter
            if (createdAt != null) localVarQueryParams.Add("created_at", Configuration.ApiClient.ParameterToString(createdAt)); // query parameter
            if (updatedAt != null) localVarQueryParams.Add("updated_at", Configuration.ApiClient.ParameterToString(updatedAt)); // query parameter
            if (datafileChecksum != null) localVarQueryParams.Add("datafile_checksum", Configuration.ApiClient.ParameterToString(datafileChecksum)); // query parameter
            if (etag != null) localVarQueryParams.Add("etag", Configuration.ApiClient.ParameterToString(etag)); // query parameter
            if (_object != null) localVarQueryParams.Add("object", Configuration.ApiClient.ParameterToString(_object)); // query parameter
            
            
            
            

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
                throw new ApiException (localVarStatusCode, "Error calling FirmwareImageDestroy: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling FirmwareImageDestroy: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<FirmwareImageSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (FirmwareImageSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(FirmwareImageSerializer)));
            
        }

        
        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;Delete firmware image&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="imageId">The ID of the firmware image</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <returns>Task of FirmwareImageSerializer</returns>
        public async System.Threading.Tasks.Task<FirmwareImageSerializer> FirmwareImageDestroyAsync (int? imageId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string _object = null)
        {
             ApiResponse<FirmwareImageSerializer> localVarResponse = await FirmwareImageDestroyAsyncWithHttpInfo(imageId, updatingRequestId, updatingIpAddress, name, description, createdAt, updatedAt, datafileChecksum, etag, _object);
             return localVarResponse.Data;

        }

        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;Delete firmware image&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="imageId">The ID of the firmware image</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <returns>Task of ApiResponse (FirmwareImageSerializer)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<FirmwareImageSerializer>> FirmwareImageDestroyAsyncWithHttpInfo (int? imageId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string _object = null)
        {
            // verify the required parameter 'imageId' is set
            if (imageId == null) throw new ApiException(400, "Missing required parameter 'imageId' when calling FirmwareImageDestroy");
            
    
            var localVarPath = "/v3/firmware/images/{image_id}/";
    
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
            if (imageId != null) localVarPathParams.Add("image_id", Configuration.ApiClient.ParameterToString(imageId)); // path parameter
            
            if (updatingRequestId != null) localVarQueryParams.Add("updating_request_id", Configuration.ApiClient.ParameterToString(updatingRequestId)); // query parameter
            if (updatingIpAddress != null) localVarQueryParams.Add("updating_ip_address", Configuration.ApiClient.ParameterToString(updatingIpAddress)); // query parameter
            if (name != null) localVarQueryParams.Add("name", Configuration.ApiClient.ParameterToString(name)); // query parameter
            if (description != null) localVarQueryParams.Add("description", Configuration.ApiClient.ParameterToString(description)); // query parameter
            if (createdAt != null) localVarQueryParams.Add("created_at", Configuration.ApiClient.ParameterToString(createdAt)); // query parameter
            if (updatedAt != null) localVarQueryParams.Add("updated_at", Configuration.ApiClient.ParameterToString(updatedAt)); // query parameter
            if (datafileChecksum != null) localVarQueryParams.Add("datafile_checksum", Configuration.ApiClient.ParameterToString(datafileChecksum)); // query parameter
            if (etag != null) localVarQueryParams.Add("etag", Configuration.ApiClient.ParameterToString(etag)); // query parameter
            if (_object != null) localVarQueryParams.Add("object", Configuration.ApiClient.ParameterToString(_object)); // query parameter
            
            
            
            

            
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
                throw new ApiException (localVarStatusCode, "Error calling FirmwareImageDestroy: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling FirmwareImageDestroy: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<FirmwareImageSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (FirmwareImageSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(FirmwareImageSerializer)));
            
        }
        
        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;List all firmware images. The result will be paged into pages of 100.&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="updatingRequestId"> (optional)</param> 
        /// <param name="updatingIpAddress"> (optional)</param> 
        /// <param name="name"> (optional)</param> 
        /// <param name="description"> (optional)</param> 
        /// <param name="createdAt"> (optional)</param> 
        /// <param name="updatedAt"> (optional)</param> 
        /// <param name="datafileChecksum"> (optional)</param> 
        /// <param name="etag"> (optional)</param> 
        /// <param name="imageId"> (optional)</param> 
        /// <param name="_object"> (optional)</param> 
        /// <param name="page">The page number to retrieve. If not given, then defaults to first page.\n (optional)</param> 
        /// <returns>List&lt;FirmwareImageSerializer&gt;</returns>
        public List<FirmwareImageSerializer> FirmwareImageList (string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string imageId = null, string _object = null, int? page = null)
        {
             ApiResponse<List<FirmwareImageSerializer>> localVarResponse = FirmwareImageListWithHttpInfo(updatingRequestId, updatingIpAddress, name, description, createdAt, updatedAt, datafileChecksum, etag, imageId, _object, page);
             return localVarResponse.Data;
        }

        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;List all firmware images. The result will be paged into pages of 100.&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="updatingRequestId"> (optional)</param> 
        /// <param name="updatingIpAddress"> (optional)</param> 
        /// <param name="name"> (optional)</param> 
        /// <param name="description"> (optional)</param> 
        /// <param name="createdAt"> (optional)</param> 
        /// <param name="updatedAt"> (optional)</param> 
        /// <param name="datafileChecksum"> (optional)</param> 
        /// <param name="etag"> (optional)</param> 
        /// <param name="imageId"> (optional)</param> 
        /// <param name="_object"> (optional)</param> 
        /// <param name="page">The page number to retrieve. If not given, then defaults to first page.\n (optional)</param> 
        /// <returns>ApiResponse of List&lt;FirmwareImageSerializer&gt;</returns>
        public ApiResponse< List<FirmwareImageSerializer> > FirmwareImageListWithHttpInfo (string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string imageId = null, string _object = null, int? page = null)
        {
            
    
            var localVarPath = "/v3/firmware/images/";
    
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
            
            if (updatingRequestId != null) localVarQueryParams.Add("updating_request_id", Configuration.ApiClient.ParameterToString(updatingRequestId)); // query parameter
            if (updatingIpAddress != null) localVarQueryParams.Add("updating_ip_address", Configuration.ApiClient.ParameterToString(updatingIpAddress)); // query parameter
            if (name != null) localVarQueryParams.Add("name", Configuration.ApiClient.ParameterToString(name)); // query parameter
            if (description != null) localVarQueryParams.Add("description", Configuration.ApiClient.ParameterToString(description)); // query parameter
            if (createdAt != null) localVarQueryParams.Add("created_at", Configuration.ApiClient.ParameterToString(createdAt)); // query parameter
            if (updatedAt != null) localVarQueryParams.Add("updated_at", Configuration.ApiClient.ParameterToString(updatedAt)); // query parameter
            if (datafileChecksum != null) localVarQueryParams.Add("datafile_checksum", Configuration.ApiClient.ParameterToString(datafileChecksum)); // query parameter
            if (etag != null) localVarQueryParams.Add("etag", Configuration.ApiClient.ParameterToString(etag)); // query parameter
            if (imageId != null) localVarQueryParams.Add("image_id", Configuration.ApiClient.ParameterToString(imageId)); // query parameter
            if (_object != null) localVarQueryParams.Add("object", Configuration.ApiClient.ParameterToString(_object)); // query parameter
            if (page != null) localVarQueryParams.Add("page", Configuration.ApiClient.ParameterToString(page)); // query parameter
            
            
            
            

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
                throw new ApiException (localVarStatusCode, "Error calling FirmwareImageList: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling FirmwareImageList: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<List<FirmwareImageSerializer>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<FirmwareImageSerializer>) Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<FirmwareImageSerializer>)));
            
        }

        
        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;List all firmware images. The result will be paged into pages of 100.&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="imageId"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="page">The page number to retrieve. If not given, then defaults to first page.\n (optional)</param>
        /// <returns>Task of List&lt;FirmwareImageSerializer&gt;</returns>
        public async System.Threading.Tasks.Task<List<FirmwareImageSerializer>> FirmwareImageListAsync (string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string imageId = null, string _object = null, int? page = null)
        {
             ApiResponse<List<FirmwareImageSerializer>> localVarResponse = await FirmwareImageListAsyncWithHttpInfo(updatingRequestId, updatingIpAddress, name, description, createdAt, updatedAt, datafileChecksum, etag, imageId, _object, page);
             return localVarResponse.Data;

        }

        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;List all firmware images. The result will be paged into pages of 100.&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="imageId"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="page">The page number to retrieve. If not given, then defaults to first page.\n (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;FirmwareImageSerializer&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<FirmwareImageSerializer>>> FirmwareImageListAsyncWithHttpInfo (string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string imageId = null, string _object = null, int? page = null)
        {
            
    
            var localVarPath = "/v3/firmware/images/";
    
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
            
            if (updatingRequestId != null) localVarQueryParams.Add("updating_request_id", Configuration.ApiClient.ParameterToString(updatingRequestId)); // query parameter
            if (updatingIpAddress != null) localVarQueryParams.Add("updating_ip_address", Configuration.ApiClient.ParameterToString(updatingIpAddress)); // query parameter
            if (name != null) localVarQueryParams.Add("name", Configuration.ApiClient.ParameterToString(name)); // query parameter
            if (description != null) localVarQueryParams.Add("description", Configuration.ApiClient.ParameterToString(description)); // query parameter
            if (createdAt != null) localVarQueryParams.Add("created_at", Configuration.ApiClient.ParameterToString(createdAt)); // query parameter
            if (updatedAt != null) localVarQueryParams.Add("updated_at", Configuration.ApiClient.ParameterToString(updatedAt)); // query parameter
            if (datafileChecksum != null) localVarQueryParams.Add("datafile_checksum", Configuration.ApiClient.ParameterToString(datafileChecksum)); // query parameter
            if (etag != null) localVarQueryParams.Add("etag", Configuration.ApiClient.ParameterToString(etag)); // query parameter
            if (imageId != null) localVarQueryParams.Add("image_id", Configuration.ApiClient.ParameterToString(imageId)); // query parameter
            if (_object != null) localVarQueryParams.Add("object", Configuration.ApiClient.ParameterToString(_object)); // query parameter
            if (page != null) localVarQueryParams.Add("page", Configuration.ApiClient.ParameterToString(page)); // query parameter
            
            
            
            

            
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
                throw new ApiException (localVarStatusCode, "Error calling FirmwareImageList: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling FirmwareImageList: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<List<FirmwareImageSerializer>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<FirmwareImageSerializer>) Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<FirmwareImageSerializer>)));
            
        }
        
        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;Retrieve firmware image&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="imageId">The ID of the firmware image</param> 
        /// <param name="updatingRequestId"> (optional)</param> 
        /// <param name="updatingIpAddress"> (optional)</param> 
        /// <param name="name"> (optional)</param> 
        /// <param name="description"> (optional)</param> 
        /// <param name="createdAt"> (optional)</param> 
        /// <param name="updatedAt"> (optional)</param> 
        /// <param name="datafileChecksum"> (optional)</param> 
        /// <param name="etag"> (optional)</param> 
        /// <param name="_object"> (optional)</param> 
        /// <returns>FirmwareImageSerializer</returns>
        public FirmwareImageSerializer FirmwareImageRetrieve (int? imageId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string _object = null)
        {
             ApiResponse<FirmwareImageSerializer> localVarResponse = FirmwareImageRetrieveWithHttpInfo(imageId, updatingRequestId, updatingIpAddress, name, description, createdAt, updatedAt, datafileChecksum, etag, _object);
             return localVarResponse.Data;
        }

        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;Retrieve firmware image&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="imageId">The ID of the firmware image</param> 
        /// <param name="updatingRequestId"> (optional)</param> 
        /// <param name="updatingIpAddress"> (optional)</param> 
        /// <param name="name"> (optional)</param> 
        /// <param name="description"> (optional)</param> 
        /// <param name="createdAt"> (optional)</param> 
        /// <param name="updatedAt"> (optional)</param> 
        /// <param name="datafileChecksum"> (optional)</param> 
        /// <param name="etag"> (optional)</param> 
        /// <param name="_object"> (optional)</param> 
        /// <returns>ApiResponse of FirmwareImageSerializer</returns>
        public ApiResponse< FirmwareImageSerializer > FirmwareImageRetrieveWithHttpInfo (int? imageId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string _object = null)
        {
            
            // verify the required parameter 'imageId' is set
            if (imageId == null)
                throw new ApiException(400, "Missing required parameter 'imageId' when calling DefaultApi->FirmwareImageRetrieve");
            
    
            var localVarPath = "/v3/firmware/images/{image_id}/";
    
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
            if (imageId != null) localVarPathParams.Add("image_id", Configuration.ApiClient.ParameterToString(imageId)); // path parameter
            
            if (updatingRequestId != null) localVarQueryParams.Add("updating_request_id", Configuration.ApiClient.ParameterToString(updatingRequestId)); // query parameter
            if (updatingIpAddress != null) localVarQueryParams.Add("updating_ip_address", Configuration.ApiClient.ParameterToString(updatingIpAddress)); // query parameter
            if (name != null) localVarQueryParams.Add("name", Configuration.ApiClient.ParameterToString(name)); // query parameter
            if (description != null) localVarQueryParams.Add("description", Configuration.ApiClient.ParameterToString(description)); // query parameter
            if (createdAt != null) localVarQueryParams.Add("created_at", Configuration.ApiClient.ParameterToString(createdAt)); // query parameter
            if (updatedAt != null) localVarQueryParams.Add("updated_at", Configuration.ApiClient.ParameterToString(updatedAt)); // query parameter
            if (datafileChecksum != null) localVarQueryParams.Add("datafile_checksum", Configuration.ApiClient.ParameterToString(datafileChecksum)); // query parameter
            if (etag != null) localVarQueryParams.Add("etag", Configuration.ApiClient.ParameterToString(etag)); // query parameter
            if (_object != null) localVarQueryParams.Add("object", Configuration.ApiClient.ParameterToString(_object)); // query parameter
            
            
            
            

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
                throw new ApiException (localVarStatusCode, "Error calling FirmwareImageRetrieve: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling FirmwareImageRetrieve: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<FirmwareImageSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (FirmwareImageSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(FirmwareImageSerializer)));
            
        }

        
        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;Retrieve firmware image&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="imageId">The ID of the firmware image</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <returns>Task of FirmwareImageSerializer</returns>
        public async System.Threading.Tasks.Task<FirmwareImageSerializer> FirmwareImageRetrieveAsync (int? imageId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string _object = null)
        {
             ApiResponse<FirmwareImageSerializer> localVarResponse = await FirmwareImageRetrieveAsyncWithHttpInfo(imageId, updatingRequestId, updatingIpAddress, name, description, createdAt, updatedAt, datafileChecksum, etag, _object);
             return localVarResponse.Data;

        }

        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware images.  &lt;/p&gt;\n&lt;p&gt;Retrieve firmware image&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="imageId">The ID of the firmware image</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <returns>Task of ApiResponse (FirmwareImageSerializer)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<FirmwareImageSerializer>> FirmwareImageRetrieveAsyncWithHttpInfo (int? imageId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string etag = null, string _object = null)
        {
            // verify the required parameter 'imageId' is set
            if (imageId == null) throw new ApiException(400, "Missing required parameter 'imageId' when calling FirmwareImageRetrieve");
            
    
            var localVarPath = "/v3/firmware/images/{image_id}/";
    
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
            if (imageId != null) localVarPathParams.Add("image_id", Configuration.ApiClient.ParameterToString(imageId)); // path parameter
            
            if (updatingRequestId != null) localVarQueryParams.Add("updating_request_id", Configuration.ApiClient.ParameterToString(updatingRequestId)); // query parameter
            if (updatingIpAddress != null) localVarQueryParams.Add("updating_ip_address", Configuration.ApiClient.ParameterToString(updatingIpAddress)); // query parameter
            if (name != null) localVarQueryParams.Add("name", Configuration.ApiClient.ParameterToString(name)); // query parameter
            if (description != null) localVarQueryParams.Add("description", Configuration.ApiClient.ParameterToString(description)); // query parameter
            if (createdAt != null) localVarQueryParams.Add("created_at", Configuration.ApiClient.ParameterToString(createdAt)); // query parameter
            if (updatedAt != null) localVarQueryParams.Add("updated_at", Configuration.ApiClient.ParameterToString(updatedAt)); // query parameter
            if (datafileChecksum != null) localVarQueryParams.Add("datafile_checksum", Configuration.ApiClient.ParameterToString(datafileChecksum)); // query parameter
            if (etag != null) localVarQueryParams.Add("etag", Configuration.ApiClient.ParameterToString(etag)); // query parameter
            if (_object != null) localVarQueryParams.Add("object", Configuration.ApiClient.ParameterToString(_object)); // query parameter
            
            
            
            

            
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
                throw new ApiException (localVarStatusCode, "Error calling FirmwareImageRetrieve: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling FirmwareImageRetrieve: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<FirmwareImageSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (FirmwareImageSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(FirmwareImageSerializer)));
            
        }
        
        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;Create firmware manifest&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="datafile">The manifest file to create</param> 
        /// <param name="name">The name of the object</param> 
        /// <param name="description">The description of the object (optional)</param> 
        /// <param name="updatingRequestId"> (optional)</param> 
        /// <param name="updatingIpAddress"> (optional)</param> 
        /// <param name="name2"> (optional)</param> 
        /// <param name="description2"> (optional)</param> 
        /// <param name="createdAt"> (optional)</param> 
        /// <param name="updatedAt"> (optional)</param> 
        /// <param name="datafileChecksum"> (optional)</param> 
        /// <param name="deviceClass"> (optional)</param> 
        /// <param name="etag"> (optional)</param> 
        /// <param name="manifestId"> (optional)</param> 
        /// <param name="_object"> (optional)</param> 
        /// <param name="timestamp"> (optional)</param> 
        /// <returns>FirmwareManifestSerializer</returns>
        public FirmwareManifestSerializer FirmwareManifestCreate (string datafile, string name, string description = null, string updatingRequestId = null, string updatingIpAddress = null, string name2 = null, string description2 = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string manifestId = null, string _object = null, string timestamp = null)
        {
             ApiResponse<FirmwareManifestSerializer> localVarResponse = FirmwareManifestCreateWithHttpInfo(datafile, name, description, updatingRequestId, updatingIpAddress, name2, description2, createdAt, updatedAt, datafileChecksum, deviceClass, etag, manifestId, _object, timestamp);
             return localVarResponse.Data;
        }

        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;Create firmware manifest&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="datafile">The manifest file to create</param> 
        /// <param name="name">The name of the object</param> 
        /// <param name="description">The description of the object (optional)</param> 
        /// <param name="updatingRequestId"> (optional)</param> 
        /// <param name="updatingIpAddress"> (optional)</param> 
        /// <param name="name2"> (optional)</param> 
        /// <param name="description2"> (optional)</param> 
        /// <param name="createdAt"> (optional)</param> 
        /// <param name="updatedAt"> (optional)</param> 
        /// <param name="datafileChecksum"> (optional)</param> 
        /// <param name="deviceClass"> (optional)</param> 
        /// <param name="etag"> (optional)</param> 
        /// <param name="manifestId"> (optional)</param> 
        /// <param name="_object"> (optional)</param> 
        /// <param name="timestamp"> (optional)</param> 
        /// <returns>ApiResponse of FirmwareManifestSerializer</returns>
        public ApiResponse< FirmwareManifestSerializer > FirmwareManifestCreateWithHttpInfo (string datafile, string name, string description = null, string updatingRequestId = null, string updatingIpAddress = null, string name2 = null, string description2 = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string manifestId = null, string _object = null, string timestamp = null)
        {
            
            // verify the required parameter 'datafile' is set
            if (datafile == null)
                throw new ApiException(400, "Missing required parameter 'datafile' when calling DefaultApi->FirmwareManifestCreate");
            
            // verify the required parameter 'name' is set
            if (name == null)
                throw new ApiException(400, "Missing required parameter 'name' when calling DefaultApi->FirmwareManifestCreate");
            
    
            var localVarPath = "/v3/firmware/manifests/";
    
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
            
            if (updatingRequestId != null) localVarQueryParams.Add("updating_request_id", Configuration.ApiClient.ParameterToString(updatingRequestId)); // query parameter
            if (updatingIpAddress != null) localVarQueryParams.Add("updating_ip_address", Configuration.ApiClient.ParameterToString(updatingIpAddress)); // query parameter
            if (name2 != null) localVarQueryParams.Add("name", Configuration.ApiClient.ParameterToString(name2)); // query parameter
            if (description2 != null) localVarQueryParams.Add("description", Configuration.ApiClient.ParameterToString(description2)); // query parameter
            if (createdAt != null) localVarQueryParams.Add("created_at", Configuration.ApiClient.ParameterToString(createdAt)); // query parameter
            if (updatedAt != null) localVarQueryParams.Add("updated_at", Configuration.ApiClient.ParameterToString(updatedAt)); // query parameter
            if (datafileChecksum != null) localVarQueryParams.Add("datafile_checksum", Configuration.ApiClient.ParameterToString(datafileChecksum)); // query parameter
            if (deviceClass != null) localVarQueryParams.Add("device_class", Configuration.ApiClient.ParameterToString(deviceClass)); // query parameter
            if (etag != null) localVarQueryParams.Add("etag", Configuration.ApiClient.ParameterToString(etag)); // query parameter
            if (manifestId != null) localVarQueryParams.Add("manifest_id", Configuration.ApiClient.ParameterToString(manifestId)); // query parameter
            if (_object != null) localVarQueryParams.Add("object", Configuration.ApiClient.ParameterToString(_object)); // query parameter
            if (timestamp != null) localVarQueryParams.Add("timestamp", Configuration.ApiClient.ParameterToString(timestamp)); // query parameter
            
            
            if (datafile != null) localVarFormParams.Add("datafile", Configuration.ApiClient.ParameterToString(datafile)); // form parameter
            if (description != null) localVarFormParams.Add("description", Configuration.ApiClient.ParameterToString(description)); // form parameter
            if (name != null) localVarFormParams.Add("name", Configuration.ApiClient.ParameterToString(name)); // form parameter
            
            

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
                throw new ApiException (localVarStatusCode, "Error calling FirmwareManifestCreate: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling FirmwareManifestCreate: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<FirmwareManifestSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (FirmwareManifestSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(FirmwareManifestSerializer)));
            
        }

        
        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;Create firmware manifest&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="datafile">The manifest file to create</param>
        /// <param name="name">The name of the object</param>
        /// <param name="description">The description of the object (optional)</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name2"> (optional)</param>
        /// <param name="description2"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="manifestId"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="timestamp"> (optional)</param>
        /// <returns>Task of FirmwareManifestSerializer</returns>
        public async System.Threading.Tasks.Task<FirmwareManifestSerializer> FirmwareManifestCreateAsync (string datafile, string name, string description = null, string updatingRequestId = null, string updatingIpAddress = null, string name2 = null, string description2 = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string manifestId = null, string _object = null, string timestamp = null)
        {
             ApiResponse<FirmwareManifestSerializer> localVarResponse = await FirmwareManifestCreateAsyncWithHttpInfo(datafile, name, description, updatingRequestId, updatingIpAddress, name2, description2, createdAt, updatedAt, datafileChecksum, deviceClass, etag, manifestId, _object, timestamp);
             return localVarResponse.Data;

        }

        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;Create firmware manifest&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="datafile">The manifest file to create</param>
        /// <param name="name">The name of the object</param>
        /// <param name="description">The description of the object (optional)</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name2"> (optional)</param>
        /// <param name="description2"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="manifestId"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="timestamp"> (optional)</param>
        /// <returns>Task of ApiResponse (FirmwareManifestSerializer)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<FirmwareManifestSerializer>> FirmwareManifestCreateAsyncWithHttpInfo (string datafile, string name, string description = null, string updatingRequestId = null, string updatingIpAddress = null, string name2 = null, string description2 = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string manifestId = null, string _object = null, string timestamp = null)
        {
            // verify the required parameter 'datafile' is set
            if (datafile == null) throw new ApiException(400, "Missing required parameter 'datafile' when calling FirmwareManifestCreate");
            // verify the required parameter 'name' is set
            if (name == null) throw new ApiException(400, "Missing required parameter 'name' when calling FirmwareManifestCreate");
            
    
            var localVarPath = "/v3/firmware/manifests/";
    
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
            
            if (updatingRequestId != null) localVarQueryParams.Add("updating_request_id", Configuration.ApiClient.ParameterToString(updatingRequestId)); // query parameter
            if (updatingIpAddress != null) localVarQueryParams.Add("updating_ip_address", Configuration.ApiClient.ParameterToString(updatingIpAddress)); // query parameter
            if (name2 != null) localVarQueryParams.Add("name", Configuration.ApiClient.ParameterToString(name2)); // query parameter
            if (description2 != null) localVarQueryParams.Add("description", Configuration.ApiClient.ParameterToString(description2)); // query parameter
            if (createdAt != null) localVarQueryParams.Add("created_at", Configuration.ApiClient.ParameterToString(createdAt)); // query parameter
            if (updatedAt != null) localVarQueryParams.Add("updated_at", Configuration.ApiClient.ParameterToString(updatedAt)); // query parameter
            if (datafileChecksum != null) localVarQueryParams.Add("datafile_checksum", Configuration.ApiClient.ParameterToString(datafileChecksum)); // query parameter
            if (deviceClass != null) localVarQueryParams.Add("device_class", Configuration.ApiClient.ParameterToString(deviceClass)); // query parameter
            if (etag != null) localVarQueryParams.Add("etag", Configuration.ApiClient.ParameterToString(etag)); // query parameter
            if (manifestId != null) localVarQueryParams.Add("manifest_id", Configuration.ApiClient.ParameterToString(manifestId)); // query parameter
            if (_object != null) localVarQueryParams.Add("object", Configuration.ApiClient.ParameterToString(_object)); // query parameter
            if (timestamp != null) localVarQueryParams.Add("timestamp", Configuration.ApiClient.ParameterToString(timestamp)); // query parameter
            
            
            if (datafile != null) localVarFormParams.Add("datafile", Configuration.ApiClient.ParameterToString(datafile)); // form parameter
            if (description != null) localVarFormParams.Add("description", Configuration.ApiClient.ParameterToString(description)); // form parameter
            if (name != null) localVarFormParams.Add("name", Configuration.ApiClient.ParameterToString(name)); // form parameter
            
            

            
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
                throw new ApiException (localVarStatusCode, "Error calling FirmwareManifestCreate: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling FirmwareManifestCreate: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<FirmwareManifestSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (FirmwareManifestSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(FirmwareManifestSerializer)));
            
        }
        
        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;Delete firmware manifest&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="manifestId">The ID of the firmware manifest</param> 
        /// <param name="updatingRequestId"> (optional)</param> 
        /// <param name="updatingIpAddress"> (optional)</param> 
        /// <param name="name"> (optional)</param> 
        /// <param name="description"> (optional)</param> 
        /// <param name="createdAt"> (optional)</param> 
        /// <param name="updatedAt"> (optional)</param> 
        /// <param name="datafileChecksum"> (optional)</param> 
        /// <param name="deviceClass"> (optional)</param> 
        /// <param name="etag"> (optional)</param> 
        /// <param name="_object"> (optional)</param> 
        /// <param name="timestamp"> (optional)</param> 
        /// <returns>FirmwareManifestSerializer</returns>
        public FirmwareManifestSerializer FirmwareManifestDestroy (int? manifestId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string _object = null, string timestamp = null)
        {
             ApiResponse<FirmwareManifestSerializer> localVarResponse = FirmwareManifestDestroyWithHttpInfo(manifestId, updatingRequestId, updatingIpAddress, name, description, createdAt, updatedAt, datafileChecksum, deviceClass, etag, _object, timestamp);
             return localVarResponse.Data;
        }

        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;Delete firmware manifest&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="manifestId">The ID of the firmware manifest</param> 
        /// <param name="updatingRequestId"> (optional)</param> 
        /// <param name="updatingIpAddress"> (optional)</param> 
        /// <param name="name"> (optional)</param> 
        /// <param name="description"> (optional)</param> 
        /// <param name="createdAt"> (optional)</param> 
        /// <param name="updatedAt"> (optional)</param> 
        /// <param name="datafileChecksum"> (optional)</param> 
        /// <param name="deviceClass"> (optional)</param> 
        /// <param name="etag"> (optional)</param> 
        /// <param name="_object"> (optional)</param> 
        /// <param name="timestamp"> (optional)</param> 
        /// <returns>ApiResponse of FirmwareManifestSerializer</returns>
        public ApiResponse< FirmwareManifestSerializer > FirmwareManifestDestroyWithHttpInfo (int? manifestId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string _object = null, string timestamp = null)
        {
            
            // verify the required parameter 'manifestId' is set
            if (manifestId == null)
                throw new ApiException(400, "Missing required parameter 'manifestId' when calling DefaultApi->FirmwareManifestDestroy");
            
    
            var localVarPath = "/v3/firmware/manifests/{manifest_id}/";
    
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
            if (manifestId != null) localVarPathParams.Add("manifest_id", Configuration.ApiClient.ParameterToString(manifestId)); // path parameter
            
            if (updatingRequestId != null) localVarQueryParams.Add("updating_request_id", Configuration.ApiClient.ParameterToString(updatingRequestId)); // query parameter
            if (updatingIpAddress != null) localVarQueryParams.Add("updating_ip_address", Configuration.ApiClient.ParameterToString(updatingIpAddress)); // query parameter
            if (name != null) localVarQueryParams.Add("name", Configuration.ApiClient.ParameterToString(name)); // query parameter
            if (description != null) localVarQueryParams.Add("description", Configuration.ApiClient.ParameterToString(description)); // query parameter
            if (createdAt != null) localVarQueryParams.Add("created_at", Configuration.ApiClient.ParameterToString(createdAt)); // query parameter
            if (updatedAt != null) localVarQueryParams.Add("updated_at", Configuration.ApiClient.ParameterToString(updatedAt)); // query parameter
            if (datafileChecksum != null) localVarQueryParams.Add("datafile_checksum", Configuration.ApiClient.ParameterToString(datafileChecksum)); // query parameter
            if (deviceClass != null) localVarQueryParams.Add("device_class", Configuration.ApiClient.ParameterToString(deviceClass)); // query parameter
            if (etag != null) localVarQueryParams.Add("etag", Configuration.ApiClient.ParameterToString(etag)); // query parameter
            if (_object != null) localVarQueryParams.Add("object", Configuration.ApiClient.ParameterToString(_object)); // query parameter
            if (timestamp != null) localVarQueryParams.Add("timestamp", Configuration.ApiClient.ParameterToString(timestamp)); // query parameter
            
            
            
            

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
                throw new ApiException (localVarStatusCode, "Error calling FirmwareManifestDestroy: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling FirmwareManifestDestroy: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<FirmwareManifestSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (FirmwareManifestSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(FirmwareManifestSerializer)));
            
        }

        
        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;Delete firmware manifest&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="manifestId">The ID of the firmware manifest</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="timestamp"> (optional)</param>
        /// <returns>Task of FirmwareManifestSerializer</returns>
        public async System.Threading.Tasks.Task<FirmwareManifestSerializer> FirmwareManifestDestroyAsync (int? manifestId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string _object = null, string timestamp = null)
        {
             ApiResponse<FirmwareManifestSerializer> localVarResponse = await FirmwareManifestDestroyAsyncWithHttpInfo(manifestId, updatingRequestId, updatingIpAddress, name, description, createdAt, updatedAt, datafileChecksum, deviceClass, etag, _object, timestamp);
             return localVarResponse.Data;

        }

        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;Delete firmware manifest&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="manifestId">The ID of the firmware manifest</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="timestamp"> (optional)</param>
        /// <returns>Task of ApiResponse (FirmwareManifestSerializer)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<FirmwareManifestSerializer>> FirmwareManifestDestroyAsyncWithHttpInfo (int? manifestId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string _object = null, string timestamp = null)
        {
            // verify the required parameter 'manifestId' is set
            if (manifestId == null) throw new ApiException(400, "Missing required parameter 'manifestId' when calling FirmwareManifestDestroy");
            
    
            var localVarPath = "/v3/firmware/manifests/{manifest_id}/";
    
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
            if (manifestId != null) localVarPathParams.Add("manifest_id", Configuration.ApiClient.ParameterToString(manifestId)); // path parameter
            
            if (updatingRequestId != null) localVarQueryParams.Add("updating_request_id", Configuration.ApiClient.ParameterToString(updatingRequestId)); // query parameter
            if (updatingIpAddress != null) localVarQueryParams.Add("updating_ip_address", Configuration.ApiClient.ParameterToString(updatingIpAddress)); // query parameter
            if (name != null) localVarQueryParams.Add("name", Configuration.ApiClient.ParameterToString(name)); // query parameter
            if (description != null) localVarQueryParams.Add("description", Configuration.ApiClient.ParameterToString(description)); // query parameter
            if (createdAt != null) localVarQueryParams.Add("created_at", Configuration.ApiClient.ParameterToString(createdAt)); // query parameter
            if (updatedAt != null) localVarQueryParams.Add("updated_at", Configuration.ApiClient.ParameterToString(updatedAt)); // query parameter
            if (datafileChecksum != null) localVarQueryParams.Add("datafile_checksum", Configuration.ApiClient.ParameterToString(datafileChecksum)); // query parameter
            if (deviceClass != null) localVarQueryParams.Add("device_class", Configuration.ApiClient.ParameterToString(deviceClass)); // query parameter
            if (etag != null) localVarQueryParams.Add("etag", Configuration.ApiClient.ParameterToString(etag)); // query parameter
            if (_object != null) localVarQueryParams.Add("object", Configuration.ApiClient.ParameterToString(_object)); // query parameter
            if (timestamp != null) localVarQueryParams.Add("timestamp", Configuration.ApiClient.ParameterToString(timestamp)); // query parameter
            
            
            
            

            
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
                throw new ApiException (localVarStatusCode, "Error calling FirmwareManifestDestroy: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling FirmwareManifestDestroy: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<FirmwareManifestSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (FirmwareManifestSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(FirmwareManifestSerializer)));
            
        }
        
        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;List all firmware manifests&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="updatingRequestId"> (optional)</param> 
        /// <param name="updatingIpAddress"> (optional)</param> 
        /// <param name="name"> (optional)</param> 
        /// <param name="description"> (optional)</param> 
        /// <param name="createdAt"> (optional)</param> 
        /// <param name="updatedAt"> (optional)</param> 
        /// <param name="datafileChecksum"> (optional)</param> 
        /// <param name="deviceClass"> (optional)</param> 
        /// <param name="etag"> (optional)</param> 
        /// <param name="manifestId"> (optional)</param> 
        /// <param name="_object"> (optional)</param> 
        /// <param name="timestamp"> (optional)</param> 
        /// <param name="page">The page number to retrieve. If not given, then defaults to first page.\n (optional)</param> 
        /// <returns>List&lt;FirmwareManifestSerializer&gt;</returns>
        public List<FirmwareManifestSerializer> FirmwareManifestList (string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string manifestId = null, string _object = null, string timestamp = null, int? page = null)
        {
             ApiResponse<List<FirmwareManifestSerializer>> localVarResponse = FirmwareManifestListWithHttpInfo(updatingRequestId, updatingIpAddress, name, description, createdAt, updatedAt, datafileChecksum, deviceClass, etag, manifestId, _object, timestamp, page);
             return localVarResponse.Data;
        }

        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;List all firmware manifests&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="updatingRequestId"> (optional)</param> 
        /// <param name="updatingIpAddress"> (optional)</param> 
        /// <param name="name"> (optional)</param> 
        /// <param name="description"> (optional)</param> 
        /// <param name="createdAt"> (optional)</param> 
        /// <param name="updatedAt"> (optional)</param> 
        /// <param name="datafileChecksum"> (optional)</param> 
        /// <param name="deviceClass"> (optional)</param> 
        /// <param name="etag"> (optional)</param> 
        /// <param name="manifestId"> (optional)</param> 
        /// <param name="_object"> (optional)</param> 
        /// <param name="timestamp"> (optional)</param> 
        /// <param name="page">The page number to retrieve. If not given, then defaults to first page.\n (optional)</param> 
        /// <returns>ApiResponse of List&lt;FirmwareManifestSerializer&gt;</returns>
        public ApiResponse< List<FirmwareManifestSerializer> > FirmwareManifestListWithHttpInfo (string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string manifestId = null, string _object = null, string timestamp = null, int? page = null)
        {
            
    
            var localVarPath = "/v3/firmware/manifests/";
    
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
            
            if (updatingRequestId != null) localVarQueryParams.Add("updating_request_id", Configuration.ApiClient.ParameterToString(updatingRequestId)); // query parameter
            if (updatingIpAddress != null) localVarQueryParams.Add("updating_ip_address", Configuration.ApiClient.ParameterToString(updatingIpAddress)); // query parameter
            if (name != null) localVarQueryParams.Add("name", Configuration.ApiClient.ParameterToString(name)); // query parameter
            if (description != null) localVarQueryParams.Add("description", Configuration.ApiClient.ParameterToString(description)); // query parameter
            if (createdAt != null) localVarQueryParams.Add("created_at", Configuration.ApiClient.ParameterToString(createdAt)); // query parameter
            if (updatedAt != null) localVarQueryParams.Add("updated_at", Configuration.ApiClient.ParameterToString(updatedAt)); // query parameter
            if (datafileChecksum != null) localVarQueryParams.Add("datafile_checksum", Configuration.ApiClient.ParameterToString(datafileChecksum)); // query parameter
            if (deviceClass != null) localVarQueryParams.Add("device_class", Configuration.ApiClient.ParameterToString(deviceClass)); // query parameter
            if (etag != null) localVarQueryParams.Add("etag", Configuration.ApiClient.ParameterToString(etag)); // query parameter
            if (manifestId != null) localVarQueryParams.Add("manifest_id", Configuration.ApiClient.ParameterToString(manifestId)); // query parameter
            if (_object != null) localVarQueryParams.Add("object", Configuration.ApiClient.ParameterToString(_object)); // query parameter
            if (timestamp != null) localVarQueryParams.Add("timestamp", Configuration.ApiClient.ParameterToString(timestamp)); // query parameter
            if (page != null) localVarQueryParams.Add("page", Configuration.ApiClient.ParameterToString(page)); // query parameter
            
            
            
            

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
                throw new ApiException (localVarStatusCode, "Error calling FirmwareManifestList: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling FirmwareManifestList: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<List<FirmwareManifestSerializer>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<FirmwareManifestSerializer>) Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<FirmwareManifestSerializer>)));
            
        }

        
        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;List all firmware manifests&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="manifestId"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="timestamp"> (optional)</param>
        /// <param name="page">The page number to retrieve. If not given, then defaults to first page.\n (optional)</param>
        /// <returns>Task of List&lt;FirmwareManifestSerializer&gt;</returns>
        public async System.Threading.Tasks.Task<List<FirmwareManifestSerializer>> FirmwareManifestListAsync (string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string manifestId = null, string _object = null, string timestamp = null, int? page = null)
        {
             ApiResponse<List<FirmwareManifestSerializer>> localVarResponse = await FirmwareManifestListAsyncWithHttpInfo(updatingRequestId, updatingIpAddress, name, description, createdAt, updatedAt, datafileChecksum, deviceClass, etag, manifestId, _object, timestamp, page);
             return localVarResponse.Data;

        }

        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;List all firmware manifests&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="manifestId"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="timestamp"> (optional)</param>
        /// <param name="page">The page number to retrieve. If not given, then defaults to first page.\n (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;FirmwareManifestSerializer&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<FirmwareManifestSerializer>>> FirmwareManifestListAsyncWithHttpInfo (string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string manifestId = null, string _object = null, string timestamp = null, int? page = null)
        {
            
    
            var localVarPath = "/v3/firmware/manifests/";
    
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
            
            if (updatingRequestId != null) localVarQueryParams.Add("updating_request_id", Configuration.ApiClient.ParameterToString(updatingRequestId)); // query parameter
            if (updatingIpAddress != null) localVarQueryParams.Add("updating_ip_address", Configuration.ApiClient.ParameterToString(updatingIpAddress)); // query parameter
            if (name != null) localVarQueryParams.Add("name", Configuration.ApiClient.ParameterToString(name)); // query parameter
            if (description != null) localVarQueryParams.Add("description", Configuration.ApiClient.ParameterToString(description)); // query parameter
            if (createdAt != null) localVarQueryParams.Add("created_at", Configuration.ApiClient.ParameterToString(createdAt)); // query parameter
            if (updatedAt != null) localVarQueryParams.Add("updated_at", Configuration.ApiClient.ParameterToString(updatedAt)); // query parameter
            if (datafileChecksum != null) localVarQueryParams.Add("datafile_checksum", Configuration.ApiClient.ParameterToString(datafileChecksum)); // query parameter
            if (deviceClass != null) localVarQueryParams.Add("device_class", Configuration.ApiClient.ParameterToString(deviceClass)); // query parameter
            if (etag != null) localVarQueryParams.Add("etag", Configuration.ApiClient.ParameterToString(etag)); // query parameter
            if (manifestId != null) localVarQueryParams.Add("manifest_id", Configuration.ApiClient.ParameterToString(manifestId)); // query parameter
            if (_object != null) localVarQueryParams.Add("object", Configuration.ApiClient.ParameterToString(_object)); // query parameter
            if (timestamp != null) localVarQueryParams.Add("timestamp", Configuration.ApiClient.ParameterToString(timestamp)); // query parameter
            if (page != null) localVarQueryParams.Add("page", Configuration.ApiClient.ParameterToString(page)); // query parameter
            
            
            
            

            
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
                throw new ApiException (localVarStatusCode, "Error calling FirmwareManifestList: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling FirmwareManifestList: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<List<FirmwareManifestSerializer>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<FirmwareManifestSerializer>) Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<FirmwareManifestSerializer>)));
            
        }
        
        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;Retrieve firmware manifest&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="manifestId">The ID of the firmware manifest</param> 
        /// <param name="updatingRequestId"> (optional)</param> 
        /// <param name="updatingIpAddress"> (optional)</param> 
        /// <param name="name"> (optional)</param> 
        /// <param name="description"> (optional)</param> 
        /// <param name="createdAt"> (optional)</param> 
        /// <param name="updatedAt"> (optional)</param> 
        /// <param name="datafileChecksum"> (optional)</param> 
        /// <param name="deviceClass"> (optional)</param> 
        /// <param name="etag"> (optional)</param> 
        /// <param name="_object"> (optional)</param> 
        /// <param name="timestamp"> (optional)</param> 
        /// <returns>FirmwareManifestSerializer</returns>
        public FirmwareManifestSerializer FirmwareManifestRetrieve (int? manifestId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string _object = null, string timestamp = null)
        {
             ApiResponse<FirmwareManifestSerializer> localVarResponse = FirmwareManifestRetrieveWithHttpInfo(manifestId, updatingRequestId, updatingIpAddress, name, description, createdAt, updatedAt, datafileChecksum, deviceClass, etag, _object, timestamp);
             return localVarResponse.Data;
        }

        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;Retrieve firmware manifest&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="manifestId">The ID of the firmware manifest</param> 
        /// <param name="updatingRequestId"> (optional)</param> 
        /// <param name="updatingIpAddress"> (optional)</param> 
        /// <param name="name"> (optional)</param> 
        /// <param name="description"> (optional)</param> 
        /// <param name="createdAt"> (optional)</param> 
        /// <param name="updatedAt"> (optional)</param> 
        /// <param name="datafileChecksum"> (optional)</param> 
        /// <param name="deviceClass"> (optional)</param> 
        /// <param name="etag"> (optional)</param> 
        /// <param name="_object"> (optional)</param> 
        /// <param name="timestamp"> (optional)</param> 
        /// <returns>ApiResponse of FirmwareManifestSerializer</returns>
        public ApiResponse< FirmwareManifestSerializer > FirmwareManifestRetrieveWithHttpInfo (int? manifestId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string _object = null, string timestamp = null)
        {
            
            // verify the required parameter 'manifestId' is set
            if (manifestId == null)
                throw new ApiException(400, "Missing required parameter 'manifestId' when calling DefaultApi->FirmwareManifestRetrieve");
            
    
            var localVarPath = "/v3/firmware/manifests/{manifest_id}/";
    
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
            
            if (updatingRequestId != null) localVarQueryParams.Add("updating_request_id", Configuration.ApiClient.ParameterToString(updatingRequestId)); // query parameter
            if (updatingIpAddress != null) localVarQueryParams.Add("updating_ip_address", Configuration.ApiClient.ParameterToString(updatingIpAddress)); // query parameter
            if (name != null) localVarQueryParams.Add("name", Configuration.ApiClient.ParameterToString(name)); // query parameter
            if (description != null) localVarQueryParams.Add("description", Configuration.ApiClient.ParameterToString(description)); // query parameter
            if (createdAt != null) localVarQueryParams.Add("created_at", Configuration.ApiClient.ParameterToString(createdAt)); // query parameter
            if (updatedAt != null) localVarQueryParams.Add("updated_at", Configuration.ApiClient.ParameterToString(updatedAt)); // query parameter
            if (datafileChecksum != null) localVarQueryParams.Add("datafile_checksum", Configuration.ApiClient.ParameterToString(datafileChecksum)); // query parameter
            if (deviceClass != null) localVarQueryParams.Add("device_class", Configuration.ApiClient.ParameterToString(deviceClass)); // query parameter
            if (etag != null) localVarQueryParams.Add("etag", Configuration.ApiClient.ParameterToString(etag)); // query parameter
            if (_object != null) localVarQueryParams.Add("object", Configuration.ApiClient.ParameterToString(_object)); // query parameter
            if (timestamp != null) localVarQueryParams.Add("timestamp", Configuration.ApiClient.ParameterToString(timestamp)); // query parameter
            
            
            if (manifestId != null) localVarFormParams.Add("manifest_id", Configuration.ApiClient.ParameterToString(manifestId)); // form parameter
            
            

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
                throw new ApiException (localVarStatusCode, "Error calling FirmwareManifestRetrieve: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling FirmwareManifestRetrieve: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);
    
            return new ApiResponse<FirmwareManifestSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (FirmwareManifestSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(FirmwareManifestSerializer)));
            
        }

        
        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;Retrieve firmware manifest&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="manifestId">The ID of the firmware manifest</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="timestamp"> (optional)</param>
        /// <returns>Task of FirmwareManifestSerializer</returns>
        public async System.Threading.Tasks.Task<FirmwareManifestSerializer> FirmwareManifestRetrieveAsync (int? manifestId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string _object = null, string timestamp = null)
        {
             ApiResponse<FirmwareManifestSerializer> localVarResponse = await FirmwareManifestRetrieveAsyncWithHttpInfo(manifestId, updatingRequestId, updatingIpAddress, name, description, createdAt, updatedAt, datafileChecksum, deviceClass, etag, _object, timestamp);
             return localVarResponse.Data;

        }

        /// <summary>
        ///  &lt;p&gt;The APIs for creating and manipulating firmware manifests.  &lt;/p&gt;\n&lt;p&gt;Retrieve firmware manifest&lt;/p&gt;
        /// </summary>
        /// <exception cref="firmware_catalog.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="manifestId">The ID of the firmware manifest</param>
        /// <param name="updatingRequestId"> (optional)</param>
        /// <param name="updatingIpAddress"> (optional)</param>
        /// <param name="name"> (optional)</param>
        /// <param name="description"> (optional)</param>
        /// <param name="createdAt"> (optional)</param>
        /// <param name="updatedAt"> (optional)</param>
        /// <param name="datafileChecksum"> (optional)</param>
        /// <param name="deviceClass"> (optional)</param>
        /// <param name="etag"> (optional)</param>
        /// <param name="_object"> (optional)</param>
        /// <param name="timestamp"> (optional)</param>
        /// <returns>Task of ApiResponse (FirmwareManifestSerializer)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<FirmwareManifestSerializer>> FirmwareManifestRetrieveAsyncWithHttpInfo (int? manifestId, string updatingRequestId = null, string updatingIpAddress = null, string name = null, string description = null, string createdAt = null, string updatedAt = null, string datafileChecksum = null, string deviceClass = null, string etag = null, string _object = null, string timestamp = null)
        {
            // verify the required parameter 'manifestId' is set
            if (manifestId == null) throw new ApiException(400, "Missing required parameter 'manifestId' when calling FirmwareManifestRetrieve");
            
    
            var localVarPath = "/v3/firmware/manifests/{manifest_id}/";
    
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
            
            if (updatingRequestId != null) localVarQueryParams.Add("updating_request_id", Configuration.ApiClient.ParameterToString(updatingRequestId)); // query parameter
            if (updatingIpAddress != null) localVarQueryParams.Add("updating_ip_address", Configuration.ApiClient.ParameterToString(updatingIpAddress)); // query parameter
            if (name != null) localVarQueryParams.Add("name", Configuration.ApiClient.ParameterToString(name)); // query parameter
            if (description != null) localVarQueryParams.Add("description", Configuration.ApiClient.ParameterToString(description)); // query parameter
            if (createdAt != null) localVarQueryParams.Add("created_at", Configuration.ApiClient.ParameterToString(createdAt)); // query parameter
            if (updatedAt != null) localVarQueryParams.Add("updated_at", Configuration.ApiClient.ParameterToString(updatedAt)); // query parameter
            if (datafileChecksum != null) localVarQueryParams.Add("datafile_checksum", Configuration.ApiClient.ParameterToString(datafileChecksum)); // query parameter
            if (deviceClass != null) localVarQueryParams.Add("device_class", Configuration.ApiClient.ParameterToString(deviceClass)); // query parameter
            if (etag != null) localVarQueryParams.Add("etag", Configuration.ApiClient.ParameterToString(etag)); // query parameter
            if (_object != null) localVarQueryParams.Add("object", Configuration.ApiClient.ParameterToString(_object)); // query parameter
            if (timestamp != null) localVarQueryParams.Add("timestamp", Configuration.ApiClient.ParameterToString(timestamp)); // query parameter
            
            
            if (manifestId != null) localVarFormParams.Add("manifest_id", Configuration.ApiClient.ParameterToString(manifestId)); // form parameter
            
            

            
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
                throw new ApiException (localVarStatusCode, "Error calling FirmwareManifestRetrieve: " + localVarResponse.Content, localVarResponse.Content);
            else if (localVarStatusCode == 0)
                throw new ApiException (localVarStatusCode, "Error calling FirmwareManifestRetrieve: " + localVarResponse.ErrorMessage, localVarResponse.ErrorMessage);

            return new ApiResponse<FirmwareManifestSerializer>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (FirmwareManifestSerializer) Configuration.ApiClient.Deserialize(localVarResponse, typeof(FirmwareManifestSerializer)));
            
        }
        
    }
    
}
