//
//  ShiftEnterRequest.swift
//  InternshipTeam
//
//  Created by Алексей Суровцев on 28.06.2024.
//

import Foundation

struct ShiftEnterRequest: Encodable {
    var shiftID: String
    var employeeID: String
    var tradePointID: String
}
