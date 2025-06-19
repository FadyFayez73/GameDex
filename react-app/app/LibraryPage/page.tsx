import Styles from './page.module.css'
import Filter from './Components/Filter/page'
import Main from './Components/Main/page'

function Library (){
    return(
        <div className={Styles.Content}>
            <div className={Styles.Filter}>
                <Filter />
            </div>
            <main className={Styles.Main}>
                <Main />
            </main>
        </div>
    )
}

export default Library;