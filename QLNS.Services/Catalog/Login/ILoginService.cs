﻿using QLNS.ViewModel.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.Services.Catalog.Login
{
    public interface ILoginService
    {
        Task<LoginRequest> Login(LoginModel loginModel);

        Task<List<LoginRequest>> GetAll();

        string GetMyName();

        string CreateToken(LoginRequest user);
    }
}