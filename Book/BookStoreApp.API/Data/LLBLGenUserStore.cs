using System.Diagnostics;
using System.Security.Claims;
using DL.DatabaseSpecific;
using DL.EntityClasses;
using DL.FactoryClasses;
using DL.HelperClasses;
using DL.Linq;
using Microsoft.AspNetCore.Identity;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.QuerySpec.Adapter;
using Serilog;

public class LLBLGenUserStore : 
    IUserStore<AspNetUserEntity>, 
    IUserEmailStore<AspNetUserEntity>, 
    IUserPasswordStore<AspNetUserEntity>, 
    IUserRoleStore<AspNetUserEntity>,
    IUserClaimStore<AspNetUserEntity>
{
    private LinqMetaData data;
    public LLBLGenUserStore(LinqMetaData data)
    {
        this.data = data;
    }

    public void Dispose()
    {
        
    }

    public Task<string> GetUserIdAsync(AspNetUserEntity user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.Id);
    }

    public Task<string> GetUserNameAsync(AspNetUserEntity user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.UserName);
    }

    public Task SetUserNameAsync(AspNetUserEntity user, string userName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetNormalizedUserNameAsync(AspNetUserEntity user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetNormalizedUserNameAsync(AspNetUserEntity user, string normalizedName, CancellationToken cancellationToken)
    {
        user.NormalizedUserName = normalizedName;
        return Task.CompletedTask;
    }

    public async Task<IdentityResult> CreateAsync(AspNetUserEntity user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        using (var adapter = new DataAccessAdapter())
        {
            AspNetUserEntity userEntity = new AspNetUserEntity();
            userEntity.Id = Guid.NewGuid().ToString();
            userEntity.UserName = user.UserName;
            userEntity.NormalizedUserName = user.UserName.ToUpper();
            userEntity.Email = user.Email;
            userEntity.NormalizedEmail = user.Email.ToUpper();
            userEntity.EmailConfirmed = user.EmailConfirmed;
            userEntity.PasswordHash = user.PasswordHash;
            userEntity.SecurityStamp = user.SecurityStamp;
            userEntity.ConcurrencyStamp = user.ConcurrencyStamp;
            userEntity.PhoneNumber = user.PhoneNumber;
            userEntity.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
            userEntity.TwoFactorEnabled = user.TwoFactorEnabled;
            userEntity.LockoutEnd = user.LockoutEnd;
            userEntity.LockoutEnabled = user.LockoutEnabled;
            userEntity.AccessFailedCount = user.AccessFailedCount;

            bool saved = await adapter.SaveEntityAsync(userEntity, cancellationToken);
            if (!saved)
            {
                return IdentityResult.Failed(new IdentityError
                    { Description = $"Could not insert user {user.Id}, {user.Email}." });
            }
        }

        return IdentityResult.Success;
    }

    public Task<IdentityResult> UpdateAsync(AspNetUserEntity user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> DeleteAsync(AspNetUserEntity user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<AspNetUserEntity> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<AspNetUserEntity> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        using (var adapter = new DataAccessAdapter())
        {
            var qf = new QueryFactory();
            var q = qf.Create()
                .Where(AspNetUserFields.NormalizedUserName.Equal(normalizedUserName))
                .Select<AspNetUserEntity, AspNetUserFields>();

            var user = await adapter.FetchFirstAsync(q, cancellationToken);

            return user;
        }
    }

    public Task SetEmailAsync(AspNetUserEntity user, string email, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetEmailAsync(AspNetUserEntity user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.Email);
    }

    public Task<bool> GetEmailConfirmedAsync(AspNetUserEntity user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetEmailConfirmedAsync(AspNetUserEntity user, bool confirmed, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<AspNetUserEntity> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
    {
        var sw = Stopwatch.StartNew();
        cancellationToken.ThrowIfCancellationRequested();
        try
        {
            using (var adapter = new DataAccessAdapter())
            {
                var qf = new QueryFactory();
                var q = qf.Create()
                    .Where(AspNetUserFields.NormalizedEmail.Equal(normalizedEmail))
                    .Select<AspNetUserEntity, AspNetUserFields>();

                var user = await adapter.FetchFirstAsync(q, cancellationToken);

                return user;
            }
        }
        finally
        {
            Log.Information("{Operation} - {TimeElapsed}", nameof(FindByEmailAsync), sw.Elapsed);
        }
    }

    public Task<string> GetNormalizedEmailAsync(AspNetUserEntity user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetNormalizedEmailAsync(AspNetUserEntity user, string normalizedEmail, CancellationToken cancellationToken)
    {
        user.NormalizedEmail = normalizedEmail;
        return Task.CompletedTask;
    }

    public Task SetPasswordHashAsync(AspNetUserEntity user, string passwordHash, CancellationToken cancellationToken)
    {
        user.PasswordHash = passwordHash;
        return Task.CompletedTask;
    }

    public Task<string> GetPasswordHashAsync(AspNetUserEntity user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.PasswordHash);
    }

    public Task<bool> HasPasswordAsync(AspNetUserEntity user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task AddToRoleAsync(AspNetUserEntity user, string roleName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        using (var adapter = new DataAccessAdapter())
        {
            var qf = new QueryFactory();
            var q = qf.AspNetRole.Where(AspNetRoleFields.NormalizedName.Equal(roleName));

            var role = await adapter.FetchFirstAsync(q, cancellationToken);

            if (role != null)
            {
                AspNetUserRoleEntity userRole = new AspNetUserRoleEntity();
                userRole.UserId = user.Id;
                userRole.RoleId = role.Id;

                await adapter.SaveEntityAsync(userRole, cancellationToken);
            }
        }
    }

    public Task RemoveFromRoleAsync(AspNetUserEntity user, string roleName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<string>> GetRolesAsync(AspNetUserEntity user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        using (var adapter = new DataAccessAdapter())
        {
            var qf = new QueryFactory();

            var q = qf.AspNetRole.From(QueryTarget
                    .InnerJoin(AspNetUserRoleEntity.Relations.AspNetRoleEntityUsingRoleId))
                .Where(AspNetUserRoleFields.UserId.Equal(user.Id));

            var userRoles = await adapter.FetchQueryAsync(q, cancellationToken);

            return userRoles.Cast<AspNetRoleEntity>().Select(ur => ur.NormalizedName).ToList();
        }
    }

    public async Task<bool> IsInRoleAsync(AspNetUserEntity user, string roleName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        IList<string> roles = await GetRolesAsync(user, cancellationToken);
        return roles.Contains(roleName);
    }

    public Task<IList<AspNetUserEntity>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<Claim>> GetClaimsAsync(AspNetUserEntity user, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        using (var adapter = new DataAccessAdapter())
        {
            var qf = new QueryFactory();
            var q = qf.AspNetUserClaim.Where(AspNetUserClaimFields.UserId.Equal(user.Id));
            var userClaims = await adapter.FetchQueryAsync(q, cancellationToken);
            return userClaims.Cast<AspNetUserClaimEntity>().Select(uc => new Claim(uc.ClaimType, uc.ClaimValue)).ToList();
        }
    }

    public Task AddClaimsAsync(AspNetUserEntity user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task ReplaceClaimAsync(AspNetUserEntity user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task RemoveClaimsAsync(AspNetUserEntity user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IList<AspNetUserEntity>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}