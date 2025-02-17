using System.Collections.Generic;
using Xunit.Internal;

namespace Xunit.v3;

/// <summary>
/// This message is sent during execution to indicate that the After method of a
/// <see cref="T:Xunit.Sdk.BeforeAfterTestAttribute"/> has completed executing.
/// </summary>
public class _AfterTestFinished : _TestMessage
{
	string? attributeName;

	/// <summary>
	/// Gets or sets the fully qualified type name of the <see cref="T:Xunit.Sdk.BeforeAfterTestAttribute"/>.
	/// </summary>
	public string AttributeName
	{
		get => this.ValidateNullablePropertyValue(attributeName, nameof(AttributeName));
		set => attributeName = Guard.ArgumentNotNull(value, nameof(AttributeName));
	}

	/// <inheritdoc/>
	public override string ToString() =>
		$"{base.ToString()} attr={attributeName.Quoted()}";

	/// <inheritdoc/>
	protected override void ValidateObjectState(HashSet<string> invalidProperties)
	{
		base.ValidateObjectState(invalidProperties);

		ValidateNullableProperty(attributeName, nameof(AttributeName), invalidProperties);
	}
}
