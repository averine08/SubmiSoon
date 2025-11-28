import type { AttemptCard } from "../types/attemptListState";
import { formatDateOnly, formatEndDateWithTime } from "../utils/dateFormat";

interface AssessmentCardProps {
    data: AttemptCard;
    activeTab: "Incomplete" | "Complete";
    openDetail: (attemptId :number) => void;
}

const AssessmentCard = ({data, activeTab, openDetail} : AssessmentCardProps ) => {

  return (
    <>
        <div className="flex flex-col p-4 gap-2 border bg-white shadow-sm rounded-md justify-between ">
            <h1 className="font-semibold">{data.title}</h1>
            <p className="text-sm">{data.description}</p>
            {activeTab === "Incomplete" ? (
                <p className="text-gray-600 text-sm mt-1">
                    {formatDateOnly(data.startDate!)} - {formatEndDateWithTime(data.endDate!)} 
                </p>
                ) : (
                <p className="text-gray-600 text-sm mt-1">
                    Submitted at : {formatEndDateWithTime(data.submittedAt!)}
                </p>
            )}

            <button onClick={() => openDetail(data.attemptId)} className={`flex text-sm self-end px-4 py-2 mt-4 rounded w-fit hover:opacity-90 cursor-pointer
                                ${activeTab == "Incomplete"? "bg-[#FD9F4D] text-white ":"bg-white border-2 border-[#FD9F4D] text-black"}`}>
                                    {activeTab === "Incomplete" ? "Start Attempt" : `Score : ${data.score!}/100`}
            </button>
        </div>
    
    </> 

  )
}

export default AssessmentCard