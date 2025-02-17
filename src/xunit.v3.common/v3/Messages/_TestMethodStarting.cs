using System.Collections.Generic;
using Xunit.Internal;

namespace Xunit.v3;

/// <summary>
/// This message indicates that a test method is about to begin executing.
/// </summary>
public class _TestMethodStarting : _TestMethodMessage, _ITestMethodMetadata
{
	string? testMethod;

	/// <inheritdoc/>
	public string TestMethod
	{
		get => this.ValidateNullablePropertyValue(testMethod, nameof(TestMethod));
		set => testMethod = Guard.ArgumentNotNullOrEmpty(value, nameof(TestMethod));
	}

	/// <inheritdoc/>
	public override string ToString() =>
		$"{base.ToString()} method={testMethod.Quoted()}";

	/// <inheritdoc/>
	protected override void ValidateObjectState(HashSet<string> invalidProperties)
	{
		base.ValidateObjectState(invalidProperties);

		ValidateNullableProperty(testMethod, nameof(TestMethod), invalidProperties);
	}
}
