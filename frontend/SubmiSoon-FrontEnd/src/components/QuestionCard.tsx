
const QuestionCard = () => {
    return (
        <div className={`flex relative w-full bg-gray-200 p-2 gap-2 `}>
            <div className="absolute top-0 right-1 text-[9px] text-[#4789E6]">Selected</div>
            <div className={`h-4 w-4 p-6 flex items-center justify-center rounded-full bg-white border-2 border-orange-300 `}>
                2
            </div>
            <div className="flex flex-col items-start justify-center">
                <p className="text-xs">Status : Answered</p>
                <p className="text-xs">Last Update: </p>
            </div>

        </div>
    )
}

export default QuestionCard