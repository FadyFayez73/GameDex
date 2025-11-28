// 'use client';

// import { createContext, useState, ReactNode, Dispatch, SetStateAction } from 'react';

// type CollapsezContextType = {
//   isCollapsed: boolean;
//   setIsCollapsed: Dispatch<SetStateAction<boolean>>;
// };


// export const CollapseContext = createContext<CollapseContextType>({
//   isCollapsed: false,
//   setIsCollapsed: () => {}, 
// });

// type CollapseProviderProps = {
//   children: ReactNode;
// };

// export function CollapseProvider({ children }: CollapseProviderProps) {
//   const [isCollapsed, setIsCollapsed] = useState(false); 

//   return (
//     <CollapseContext.Provider value={{ isCollapsed, setIsCollapsed }}>
//       {children}
//     </CollapseContext.Provider>
//   );
// }
