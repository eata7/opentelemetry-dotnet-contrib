// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Diagnostics;
using Microsoft.Owin;

namespace OpenTelemetry.Instrumentation.Owin;

/// <summary>
/// Options for requests instrumentation.
/// </summary>
public class OwinInstrumentationOptions
{
    /// <summary>
    /// Gets or sets a Filter function that determines whether or not to collect telemetry about requests on a per request basis.
    /// The Filter gets the <see cref="IOwinContext"/>, and should return a boolean.
    /// If Filter returns true, the request is collected.
    /// If Filter returns false or throw exception, the request is filtered out.
    /// </summary>
    public Func<IOwinContext, bool> Filter { get; set; }

    /// <summary>
    /// Gets or sets an action to enrich the <see cref="Activity"/> created by the instrumentation.
    /// </summary>
    public Action<Activity, OwinEnrichEventType, IOwinContext, Exception> Enrich { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the exception will be recorded as <see cref="ActivityEvent"/> or not.
    /// </summary>
    /// <remarks>
    /// https://github.com/open-telemetry/opentelemetry-specification/blob/main/specification/trace/semantic_conventions/exceptions.md.
    /// </remarks>
    public bool RecordException { get; set; }
}
