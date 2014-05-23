﻿// This file is part of iRacingReplayOverlay.
//
// Copyright 2014 Dean Netherton
// https://github.com/vipoo/iRacingReplayOverlay.net
//
// iRacingReplayOverlay is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// iRacingReplayOverlay is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with iRacingReplayOverlay.  If not, see <http://www.gnu.org/licenses/>.
//

using MediaFoundation.Net;
using System;

namespace iRacingReplayOverlay.Video
{
    public partial class AVOperation
    {
        public static ProcessSample ApplyEditWithFade(long starting, long finishing, ProcessSample next)
        {
            return ApplyEdit(starting, finishing, 
                FadeOut(starting - 1.FromSecondsToNano(), 1.FromSecondsToNano(), next),
                FadeIn(next));
        }

        public static ProcessSample ApplyEdit(long starting, long finishing, ProcessSample beforeEdit, ProcessSample afterEdit)
        {
            return SplitFrom(starting, beforeEdit, SkipTo(finishing, afterEdit));
        }
    }
}