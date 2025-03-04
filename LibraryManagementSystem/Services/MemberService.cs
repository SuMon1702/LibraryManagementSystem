﻿using LibraryManagementSystem.LibraryManagement.Utlis;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;

namespace LibraryManagementSystem.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }
        public async Task<Result<List<TblMember?>>> GetMembersAsync()
        {
            return await _memberRepository.GetMembersAsync();
        }

        public async Task<Result<TblMember?>> GetMemberByIdAsync(int id)
        {
            return await _memberRepository.GetMemberByIdAsync(id);
        }
    }
}
