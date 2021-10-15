﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.StateActions
{
    public class SAStopJump : StateAction
    {
        public bool StopAll { get; set; }
        public string JumpId { get; set; }

        public SAStopJump()
        {
        }

        internal SAStopJump(BulkSerializer reader) : base(reader)
        {
            StopAll = reader.ReadBool();
            JumpId = reader.ReadString();
        }
    }
}