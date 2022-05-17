using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.Jumps
{
	[Serializable]
	public class ClampMomentumJump : Jump
	{
		public ClampMomentumJump()
		{ }

		internal ClampMomentumJump(BulkSerializeReader reader) : base(reader)
		{ }

		public override void Write(BulkSerializeWriter writer)
		{
			base.Write(writer);
		}
	}
}
