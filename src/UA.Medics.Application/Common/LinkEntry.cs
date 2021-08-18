using System;

namespace UA.Medics.Application
{
	public record LinkEntry (
			Uri Link,
			DateTime UploadDate
		);
}
