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

using iRacingSDK;

namespace iRacingReplayOverlay.Phases.Direction
{
    public static class RuleVetoExtensions
    {
        public static IDirectionRule WithVeto(this IDirectionRule mainRule, IDirectionRule vetoRule)
        {
            return new RuleVeto(mainRule, vetoRule);
        }
    }

    public class RuleVeto : IDirectionRule
    {
        readonly IDirectionRule mainRule;
        readonly IDirectionRule vetoRule;

        bool isVetoed = false;

        public RuleVeto(IDirectionRule mainRule, IDirectionRule vetoRule)
        {
            this.mainRule = mainRule;
            this.vetoRule = vetoRule;
        }

        public bool IsActive(DataSample data)
        {
            if (isVetoed = vetoRule.IsActive(data))
                return true;

            return mainRule.IsActive(data);
        }

        public void Direct(DataSample data)
        {
            if (isVetoed)
            {
                vetoRule.Direct(data);
                return;
            }

            mainRule.Direct(data);
        }
    }
}