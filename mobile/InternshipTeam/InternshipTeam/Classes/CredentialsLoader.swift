//
//  CredentialsLoader.swift
//  InternshipTeam
//
//  Created by Алексей Суровцев on 18.06.2024.
//

import Foundation


final class CredentialsLoader {
    
    public static func downloadCredentials(completion: @escaping(AuthorizeRequest?) -> Void) {
        
        completion(AuthorizeRequest(login: UserDefaults.standard.string(forKey: "login"), password: UserDefaults.standard.string(forKey: "password")))
        
    }
    
}
