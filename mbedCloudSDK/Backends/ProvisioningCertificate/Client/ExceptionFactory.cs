/* 
 * Provisioning endpoints - provisioning certificates.
 *
 * A provisioning certificate is used to associate an mbed Cloud account with a specific installation of a Factory Tool. The certificate needs to be downloaded using this API and placed into the appropriate directory of the Factory Tool. 
 *
 * OpenAPI spec version: 0.8
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */


using System;
using RestSharp;

namespace provisioning_certificate.Client
{
    /// <summary>
    /// A delegate to ExceptionFactory method
    /// </summary>
    /// <param name="methodName">Method name</param>
    /// <param name="response">Response</param>
    /// <returns>Exceptions</returns>    
    public delegate Exception ExceptionFactory(string methodName, IRestResponse response);
}
