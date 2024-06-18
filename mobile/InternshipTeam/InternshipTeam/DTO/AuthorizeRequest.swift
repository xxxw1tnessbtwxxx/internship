//
//  AuthorizeRequest.swift
//  InternshipTeam
//
//  Created by Алексей Суровцев on 17.06.2024.
//

import Foundation

struct AuthorizeRequest: Encodable {
    
    let login, password: String?
    
}
