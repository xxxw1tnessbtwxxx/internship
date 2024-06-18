//
//  EmployeeDTO.swift
//  InternshipTeam
//
//  Created by Алексей Суровцев on 17.06.2024.
//

import Foundation

// MARK: - EmployeeDTO
struct EmployeeDTO: Codable {
    let id, login, password, surname: String
    let name, patronymic, phoneNumber: String
    let genderID: Int
    let gender: Gender
    let access: Access
}

// MARK: - Access
struct Access: Codable {
    let id, tradePointID: String
    let tradePoint: TradePoint
}

// MARK: - TradePoint
struct TradePoint: Codable {
    let id, pointName: String
}

// MARK: - Gender
struct Gender: Codable {
    let id: Int
    let name: String
}
