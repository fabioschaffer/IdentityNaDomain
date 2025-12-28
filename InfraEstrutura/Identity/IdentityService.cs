using Aplicacao.Interfaces;
using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraEstrutura.Identity;

public class IdentityService : IIdentityService {
    private readonly UserManager<ApplicationUser> _userManager;

    public IdentityService(UserManager<ApplicationUser> userManager) {
        _userManager = userManager;
    }

    public async Task<string?> GetUserIdAsync(string email) {
        var user = await _userManager.FindByEmailAsync(email);
        return user?.Id;
    }

    public async Task<bool> CheckPasswordAsync(string userId, string password) {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return false;

        return await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task<bool> CreateUserAsync(
        string email,
        string password,
        string nomeCompleto) {
        var user = new ApplicationUser {
            UserName = email,
            Email = email,
            NomeCompleto = nomeCompleto
        };

        var result = await _userManager.CreateAsync(user, password);
        return result.Succeeded;
    }
}
