//
//  DateTimeParser.swift
//  InternshipTeam
//
//  Created by Алексей Суровцев on 29.06.2024.
//

import Foundation

class DateTimeParser {
    
    
    private init() {
        
    }
    public static func GetDate(_ fromDate: String) -> String? {
        
        let dateFormatter = DateFormatter()
            dateFormatter.locale = Locale(identifier: "en_US_POSIX") // устанавливаем локаль для корректного парсинга даты
            dateFormatter.dateFormat = "yyyy-MM-dd'T'HH:mm:ss.SSSSSS" // устанавливаем формат даты, соответствующий вашей строке
            if let date = dateFormatter.date(from: fromDate) { // преобразуем строку в дату
                dateFormatter.dateFormat = "HH:mm:ss dd.MM.yyyy" // устанавливаем формат даты, соответствующий требуемому формату вывода
                let formattedDate = dateFormatter.string(from: date) // преобразуем дату в строку в требуемом формате
                return formattedDate
            } else {
                print("Некорректная дата") // выводим сообщение об ошибке
                return nil
            }
        
    }
    
    
    public static func calculateTotalHours(from dates: [WorkTime]) -> Double {
        var totalHours: Double = 0
        for date in dates {
            if let comeDt = ISO8601DateFormatter().date(from: date.comeDate),
               let leaveDt = ISO8601DateFormatter().date(from: date.leaveDate) {
                let comeHours = Double(comeDt.hour)
                let comeMinutes = Double(comeDt.minute) / 60
                let leaveHours = Double(leaveDt.hour)
                let leaveMinutes = Double(leaveDt.minute) / 60
                
                print("asd \(comeHours)")
                print(leaveHours)
                
                let workHours = leaveHours + leaveMinutes / 60 - (comeHours + comeMinutes / 60)
                totalHours += workHours
            }
        }
        return totalHours
    }
}



extension Date {
    var hour: Int {
        return Calendar.current.component(.hour, from: self)
    }
    
    var minute: Int {
        return Calendar.current.component(.minute, from: self)
    }
}
