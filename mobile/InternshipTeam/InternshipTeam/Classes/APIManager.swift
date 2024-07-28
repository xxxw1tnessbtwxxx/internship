//
//  APIManager.swift
//  InternshipTeam
//
//  Created by Алексей Суровцев on 17.06.2024.
//

import Foundation
import Alamofire

final class APIManager {
    
    
    static let baseUrl: String = "https://5dee-188-162-14-203.ngrok-free.app"
    
    public static func getEmployee(authRequest: AuthorizeRequest, completion: @escaping (EmployeeDTO?) -> Void) {
        
        
        let authRequestJson = try! JSONSerialization.jsonObject(with: try! JSONEncoder().encode(authRequest), options: []) as! [String: Any]
        
        let headers: HTTPHeaders = [
            "ngrok-skip-browser-warning": "true"
        ]
        
        AF.request("\(baseUrl)/api/v1/Authentication/signin", method: .post, parameters: authRequestJson, encoding: JSONEncoding.default, headers: headers).response { response in
        
            guard let data = response.data else { completion(nil); return }
            DispatchQueue.main.async {
                completion(try! JSONDecoder().decode(EmployeeDTO.self, from: data))
            }
        }
    }
    
    public static func enterShift(_ enterRequest: ShiftEnterRequest, completion: @escaping(String) -> Void) {
        let enterRequestJson = try! JSONSerialization.jsonObject(with: try! JSONEncoder().encode(enterRequest), options: []) as! [String: Any]
        
        let headers: HTTPHeaders = [
            "ngrok-skip-browser-warning": "true"
        ]
        
        print(enterRequestJson)
        
        AF.request("\(baseUrl)/api/v1/Shifts/ShiftEmployeeInteract", method: .post, parameters: enterRequestJson, encoding: JSONEncoding.default, headers: headers).response { response in
        
            guard let data = response.data else { completion("error"); return }
            if (response.response!.statusCode != 200) {
                completion("API Error \(response.response!.statusCode)")
            }
            DispatchQueue.main.async {
                completion(String(data: data, encoding: .utf8)!)
            }
        }
        
        
    }

    
    public static func getEmployeeData(completion: @escaping(EmployeeData) -> Void) {
        
        
        
        let headers: HTTPHeaders = [
            "ngrok-skip-browser-warning": "true"
        ]
        var response = AF.request("\(baseUrl)/api/v1/Shifts/GetEmployeeData?employeeId=\(CurrentData.employee!.id)", method: .get, headers: headers).response { response in
            
            
            guard let data = response.data else {
                return
            }
            
            if (response.response!.statusCode != 200) {
                return
            }
            
            let employeelist = try! JSONDecoder().decode(EmployeeData.self, from: data)
            completion(employeelist)
            
        }
        
    }
    
}
    

