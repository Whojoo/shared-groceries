using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Http.Features;

namespace SharedGrocery.Tests.TestUtil.Rest
{
    public class TestHttpContext : HttpContext
    {
        public TestHttpContext(HttpRequest request)
        {
            Request = request;
        }

        // Important overrides
        public override HttpRequest Request { get; }

        // Overrides we don't care about.
        public override void Abort()
        {
        }
        
        public override IFeatureCollection Features { get; }
        public override HttpResponse Response { get; }
        public override ConnectionInfo Connection { get; }
        public override WebSocketManager WebSockets { get; }
        public override AuthenticationManager Authentication { get; }
        public override ClaimsPrincipal User { get; set; }
        public override IDictionary<object, object> Items { get; set; }
        public override IServiceProvider RequestServices { get; set; }
        public override CancellationToken RequestAborted { get; set; }
        public override string TraceIdentifier { get; set; }
        public override ISession Session { get; set; }
    }
}