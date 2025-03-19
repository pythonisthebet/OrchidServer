﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidServer.DTO
{
    public class chToJsonWithUidAndCid
    {
        public ExpandoObject character;

        public int Uid;

        public int Cid;

        public chToJsonWithUidAndCid()
        {
            ExpandoObject empty = new ExpandoObject();
            Uid = 0;
            Cid = 0;
        }

        public chToJsonWithUidAndCid(int uid, int cid)
        {
            ExpandoObject empty = new ExpandoObject();
            Uid = uid;
            Cid = cid;
        }

        public chToJsonWithUidAndCid(ExpandoObject Character, int uid, int cid)
        {
            ExpandoObject ch = Character;
            Uid = uid;
            Cid = cid;
        }

    }
}
