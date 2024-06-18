//
//  CurrentData.swift
//  InternshipTeam
//
//  Created by Алексей Суровцев on 17.06.2024.
//

import Foundation

class CurrentData {
    
    private init() {}
    
    
    public static var employee: EmployeeDTO? = nil
    public static var employeeSalary: Double = 0
    
    public static func disposeDefaults() {
        UserDefaults.standard.removeObject(forKey: "salary")
        UserDefaults.standard.removeObject(forKey: "login")
        UserDefaults.standard.removeObject(forKey: "password")
    }
}
