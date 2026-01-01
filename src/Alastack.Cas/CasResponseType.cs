namespace Alastack.Cas;

/// <summary>
/// Specifies the type of CAS protocol validation response.
/// This enumeration represents the possible outcomes of a CAS validation request.
/// </summary>
public enum CasResponseType
{
    /// <summary>
    /// Unspecified
    /// </summary>
    Unspecified = 0,
    /// <summary>
    /// CAS 1.0 Validate
    /// </summary>
    Validate = 1,
    /// <summary>
    /// CAS 2.0 ServiceValidate
    /// </summary>
    ServiceValidate = 2,
    /// <summary>
    /// CAS 2.0+ roxyValidate
    /// </summary>
    ProxyValidate = 3,
    /// <summary>
    /// CAS 2.0+ Proxy
    /// </summary>
    Proxy = 4

}
