namespace Alastack.Cas;

/// <summary>
/// Represents a CAS service validation response according to the CAS protocol specification.
/// This class parses and encapsulates the response from CAS validation endpoints (/serviceValidate, /proxyValidate).
/// Reference: https://apereo.github.io/cas/7.2.x/protocol/CAS-Protocol-Specification.html
/// </summary>
public class CasResponse
{
    /// <summary>
    /// Gets or sets the type of CAS validation response.
    /// This indicates the outcome of the validation request (success/failure for authentication or proxy).
    /// </summary>
    public CasResponseType ResponseType { get; internal set; } = CasResponseType.Unspecified;

    /// <summary>
    /// Gets the raw XML response data as received from the CAS server.
    /// This is the complete, unparsed response body from the validation endpoint.
    /// </summary>
    public string Data { get; }

    /// <summary>
    /// Gets or sets the authenticated user identifier (username).
    /// This value is extracted from the &lt;cas:user&gt; element in successful authentication responses.
    /// </summary>
    public string UserName { get; internal set; }

    /// <summary>
    /// Gets or sets the Proxy-Granting Ticket (PGT) identifier.
    /// This value is extracted from the &lt;cas:proxyGrantingTicket&gt; element in CAS 2.0+ responses.
    /// </summary>
    public string ProxyGrantingTicket { get; internal set; }

    /// <summary>
    /// Gets the list of proxy URLs that were involved in the authentication chain.
    /// This collection is populated from the &lt;cas:proxies&gt; element in CAS 2.0+ responses.
    /// </summary>
    public IList<string> Proxies { get; }

    /// <summary>
    /// Gets or sets the proxy ticket identifier.
    /// This value is extracted from the &lt;cas:proxyTicket&gt; element in proxy validation responses.
    /// </summary>
    public string ProxyTicket { get; internal set; }

    /// <summary>
    /// Gets or sets the standardized error code for failed validations.
    /// This value is extracted from the <c>code</c> attribute of &lt;cas:authenticationFailure&gt; or &lt;cas:proxyFailure&gt; elements.
    /// </summary>
    public string FailureCode { get; internal set; }

    /// <summary>
    /// Gets or sets the human-readable error description.
    /// This value is extracted from the text content of &lt;cas:authenticationFailure&gt; or &lt;cas:proxyFailure&gt; elements.
    /// </summary>
    public string Error { get; internal set; }

    /// <summary>
    /// Gets the dictionary of additional user attributes.
    /// These values are extracted from the &lt;cas:attributes&gt; element and its children in CAS 3.0+ responses.
    /// </summary>
    public IDictionary<string, string> Attributes { get; }


    /// <summary>
    /// Initializes a new instance of the <see cref="CasResponse"/> class with the specified raw response data.
    /// </summary>
    /// <param name="data">
    /// The raw XML response data from a CAS validation endpoint.
    /// This should be the complete response body from /serviceValidate or /proxyValidate.
    /// </param>
    public CasResponse(string data)
    {
        Data = data;
        Proxies = new List<string>();
        Attributes = new Dictionary<string, string>();
    }
}
