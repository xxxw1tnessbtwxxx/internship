//
//  EmployeeWorkData.swift
//  InternshipTeam
//
//  Created by Алексей Суровцев on 28.06.2024.
//

import Foundation

// MARK: - EmployeeDatum
struct EmployeeDatum: Codable {
    let id, comeDate, leaveDate, tradePointID: String
    let tradePoint: TradePointDTO
}

// MARK: - TradePoint
struct TradePointDTO: Codable {
    let id, pointName: String
}

typealias EmployeeData = [EmployeeDatum]
