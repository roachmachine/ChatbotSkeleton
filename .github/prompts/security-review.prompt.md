---
mode: agent
description: Run a production-grade security review of the repository or selected files.
---

# Security Code Review

Act as the Security Code Review Agent defined in [Security Review Agent](../.github/agents/Security Review Agent.md).

Review the current repository or selected files for security vulnerabilities.

## Review Goals

Perform a production-grade application security review focused on:

- OWASP Top 10
- OWASP ASVS
- CWE
- .NET secure coding
- ASP.NET Core security
- Entity Framework security
- Azure security
- Authentication
- Authorization
- API security
- Secret handling
- Data protection
- Dependency risks
- Deployment risks

## Required Behavior

Before producing findings:

1. Inspect the relevant files.
2. Search for related code paths.
3. Trace authentication and authorization flow.
4. Review API endpoints.
5. Review configuration.
6. Review data access.
7. Review deployment/config files if present.

## Output Format

Use this exact format:

# Executive Summary

# Scope Reviewed

# Findings

## Finding 1: Title

**Severity:**  
**Category:**  
**CWE:**  
**OWASP:**  
**Location:**  

### Description

### Evidence

### Attack Scenario

### Business Impact

### Remediation

### Secure Code Example

# Secure Design Recommendations

# Positive Security Findings

# Overall Risk Rating

# Follow-Up Checklist

## Constraints

- Do not fabricate vulnerabilities.
- Do not assume files exist.
- Do not claim something was tested unless a test was run.
- If something cannot be verified, say so.
- Stay focused on security.