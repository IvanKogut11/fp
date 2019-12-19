﻿using System.Collections.Generic;
using TagsCloudContainer.Models;

namespace TagsCloudContainer
{
    public interface IUserHandler
    {
        Result<InputInfo> GetInputInfo();
    }
}