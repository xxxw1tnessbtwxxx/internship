//
//  APIManager.swift
//  InternshipTeam
//
//  Created by Алексей Суровцев on 17.06.2024.
//

import Foundation
import Alamofire

final class APIManager {
    
    public static func getEmployee(authRequest: AuthorizeRequest, completion: @escaping (EmployeeDTO?) -> Void) {
        
        
        let authRequestJson = try! JSONSerialization.jsonObject(with: try! JSONEncoder().encode(authRequest), options: []) as! [String: Any]
        
        AF.request("http://localhost:5281/api/v1/Authentication/signin", method: .post, parameters: authRequestJson, encoding: JSONEncoding.default).response { response in
        
            guard let data = response.data else { completion(nil); return }
            DispatchQueue.main.async {
                completion(try! JSONDecoder().decode(EmployeeDTO.self, from: data))
            }
        }
    }
}
    

