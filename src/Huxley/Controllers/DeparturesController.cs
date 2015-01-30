﻿/*
Huxley - a JSON proxy for the UK National Rail Live Departure Board SOAP API
Copyright (C) 2015 James Singleton
 * http://huxley.unop.uk
 * https://github.com/jpsingleton/Huxley

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published
by the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Threading.Tasks;
using Huxley.ldbServiceReference;

namespace Huxley.Controllers {
    public class DeparturesController : BaseController {
        // GET /departures/CRS?accessToken=[your token]
        public async Task<StationBoard> Get(string id, Guid accessToken) {

            var client = new LDBServiceSoapClient();
            var token = MakeAccessToken(accessToken);

            var board = await client.GetDepartureBoardAsync(token, 42, id.ToUpperInvariant(), null, FilterType.to, 0, 0);
            return board.GetStationBoardResult;

        }
    }
}