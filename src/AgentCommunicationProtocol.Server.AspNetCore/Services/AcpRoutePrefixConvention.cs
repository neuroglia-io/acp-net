using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace AgentCommunicationProtocol.Server.Services;

/// <summary>
/// Represents an <see cref="IApplicationModelConvention"/> used to prefix ACP controllers as configured
/// </summary>
/// <param name="prefix">The prefix to use</param>
public class AcpRoutePrefixConvention(string prefix)
    : IApplicationModelConvention
{

    readonly AttributeRouteModel _prefix = new AttributeRouteModel(new RouteAttribute(prefix));

    /// <inheritdoc/>
    public void Apply(ApplicationModel application)
    {
        foreach (var controller in application.Controllers.Where(c => c.ControllerType.Assembly == GetType().Assembly))
        {
            foreach (var selector in controller.Selectors.Where(s => s.AttributeRouteModel != null))
            {
                selector.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(_prefix, selector.AttributeRouteModel);
            }
        }
    }

}
